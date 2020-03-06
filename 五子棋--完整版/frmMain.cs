using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace 五子棋__完整版
{
    public partial class frmMain : Form
    {
        //网络通信涉及类
        TcpListener _listener = null;
        TcpClient _client = null;
        NetworkStream _netStream = null;
        StreamReader _sr = null;
        StreamWriter _sw = null;

        bool _serverOk = false;
        bool _clientOk = false;

        //网络角色
        GameRole _role;

        bool _rungame = false;
        Image _baseImage;//棋盘图片
        Image _cursorImage;//光标图片
        Image _blackChess;//黑
        Image _whiteChess;//白

        int _logicX, _logicY, _physicsX, _physicsY;//落在的坐标点
        Graphics _gs;//绘制画笔

        ChessType _chess;   //白|黑
        ChessType _gameType;    //棋子类型

        int[,] chessArray;

        

        public frmMain()
        {
            InitializeComponent();
        }
        //窗口加载
        private void frmMain_Load(object sender, EventArgs e)
        {
            //画布、光标
            this._baseImage = Properties.Resources.chessboard__1;
            this._cursorImage = Properties.Resources.Cursor;
            this._blackChess = Properties.Resources.黑子;
            this._whiteChess = Properties.Resources.白子;

            //画笔
            this._gs = Graphics.FromImage(this._baseImage);


            chessArray = new int[15, 15];
            //二维数组坐标


        }
        
        /// <summary>
        /// 开始游戏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiStart_Click(object sender, EventArgs e)
        {

            //在线情况
            if (_role == GameRole.擂主)
                _serverOk = true;
            else
                _clientOk = true;

            this.lblServe.Text = "等待对方加入";
            
            this.writeMessage("stare:start");

            //如果对方加入游戏运行下棋操作
            StartGame();
        }
        /// <summary>
        /// 初始化数据并开始游戏
        /// </summary>
        private void StartGame()
        {
            if (_serverOk && _clientOk)
            {
                //运行
                this._rungame = true;

                //初始化数据
                this._baseImage = Properties.Resources.chessboard__1;
                this._gs = Graphics.FromImage(this._baseImage);

                //初始化二维数组坐标
                chessArray = new int[15, 15];
                //先手
                this._chess = ChessType.黑子;

                //刷新显示
                this.pictureBox1.Invoke(new Action(() => this.pictureBox1.Image = this._baseImage));

                this.lblServe.Invoke(new Action(() => this.lblServe.Text = "游戏开始..."));


            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._rungame == false || _gameType != _chess) return; //没有开始游戏

            //产生一个新画笔
            Image tempImage = (Image)this._baseImage.Clone();

            //基于新画布的画笔
            Graphics gs = Graphics.FromImage(tempImage);

            //可能落子点
            _logicX = ((e.X - 20) % 40 < 20) ? (e.X - 20) / 40 : (e.X - 20) / 40 + 1;
            _logicY = ((e.Y - 20) % 40 < 20) ? (e.Y - 20) / 40 : (e.Y - 20) / 40 + 1;


            _physicsX = _logicX * 40;
            _physicsY = _logicY * 40;

            this.lblLogic.Text = string.Format("逻辑坐标---- {0} : {1}",_logicX,_logicY);
            this.lblPhysics.Text = string.Format("逻辑坐标---- {0} : {1}", _physicsX, _physicsY);
            //绘制
            if (this.chessArray[_logicX, _logicY] == 0)
            {
                gs.DrawImage(this._cursorImage, _physicsX, _physicsY, 40, 40);
            }
            else//用特殊图片，表示不能下棋
            {
                gs.DrawImage(Properties.Resources.forbid, _physicsX, _physicsY, 40, 40);
            }
            //从新放到相框中
            this.pictureBox1.Image = tempImage;
        }
        //下棋
        //bool isok = true;//默认黑棋
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this._rungame == false || this._gameType != _chess) return ;//可以下棋吗   ---禁手判断
            //禁手判断
            //if (chess() == false) return;

            //左键
            if (this._rungame != false)
            {
                if (e.Button == MouseButtons.Left)   //左键被按下
                {
                    ChessType tempChess = this._chess;  //落下棋子类型
                                                        //落子无悔、显示到棋盘
                                                        //输赢判断
                    this.GameGudge(_logicX, _logicY, tempChess, e);

                }
            }

        }

        private void 服务开启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //玩家棋子类型
            this._gameType = ChessType.黑子;

            IPAddress myIP = NetService.GetLocalIP();//本机ip

            IPEndPoint myPort = new IPEndPoint(myIP,2000);
            _listener = new TcpListener(myPort);

            _listener.Start();
            string ipport = _listener.LocalEndpoint.ToString();
            this.lblServe.Text = "已在【" + ipport + "】开始监听...";


            //设置角色
            this._role = GameRole.擂主;
            this.加入游戏ToolStripMenuItem.Enabled = false;
            //设置多线程等待玩家的接入

            //开启线程，代替手工接收
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                //阻塞方法：AcceptTcpClient()，导致线程在此等待
                this._client = _listener.AcceptTcpClient();//client可以与远程交互
                this.lblServe.Invoke(new Action(() => this.lblServe.Text = "玩家已经上线，等待开始！"));

                //搭建数据交换通道
                _netStream = this._client.GetStream();
                _sr = new StreamReader(_netStream);
                _sw = new StreamWriter(_netStream);
                _sw.AutoFlush = true;

                //启动连续的消息接收线程
                ReadMessage();

            }, null);


        }


        private void 加入游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //玩家类型
            this._gameType = ChessType.白子;

            //打开连接界面
            this.groupBox1.Visible = true;
            //直接获取本机服务器监听的IP和端口后
            this.txtIP.Text = NetService.GetLocalIP().ToString();
            this.txtPort.Text = NetService.SERVERPORT.ToString();

            //设置角色
            this._role = GameRole.挑战者;
            this.服务开启ToolStripMenuItem.Enabled = false;

            
        }


        /// <summary>
        /// 连接服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnete_Click(object sender, EventArgs e)
        {
            //开始连接隐藏界面
            this.groupBox1.Visible = false;
            try
            {
                //方式二：随机端口，进行远程连接
                _client = new TcpClient();
                _client.Connect(this.txtIP.Text, int.Parse(this.txtPort.Text));
                this.lblServe.Text = "已经连接服务器...";


                //搭建数据交换通道
                _netStream = _client.GetStream();
                _sr = new StreamReader(_netStream);
                _sw = new StreamWriter(_netStream);
                _sw.AutoFlush = true;//你一写，就马上传输

                //等待消息到来
                ReadMessage();

            }
            catch (Exception ex)
            {
                this.lblServe.Text = ex.Message;
            }
        }

        //连续接收消息，显示到界面
        void ReadMessage()
        {
            //线程中，再启用线程，负责连续接收
            ThreadPool.QueueUserWorkItem((obj1) => {
                do
                {
                    //有数据可以读取
                    if (_netStream.DataAvailable && _sr != null)
                    {
                        string temp = _sr.ReadLine();

                        //调试状态显示出来
                        this.listBox1.Invoke(new Action<string>(item => this.listBox1.Items.Add(item)), temp);

                        //消息切分
                        string messType = temp.Split(':')[0];
                        switch (messType)
                        {
                            case "stare":
                                string submess = temp.Split(':')[1];
                                if (submess == "start")
                                {
                                    if (_role == GameRole.擂主)
                                        _clientOk = true;//你是擂主，ok一定是客户端
                                    else
                                        _serverOk = true;

                                    //判断是否可以开始游戏
                                    StartGame();
                                }

                                break;
                            case "downchess": //处理落子
                                string[] infoArray = temp.Split(':')[1].Split('|');
                                int x = int.Parse(infoArray[0]);
                                int y = int.Parse(infoArray[1]);
                                string type = infoArray[2];
                                //新增一个绘制方法
                                DrawChess(x, y, type);

                                break;
                            case "mess": //聊天消息
                                break;
                            default:
                                break;
                        }




                        //最后，应该演变为：
                        //1、绘制到界面
                        //2、换手



                    }
                    Thread.Sleep(100);

                } while (true);
            }, null);
        }

        private void DrawChess(int x, int y, string type)
        {
            //当前落子  ---string 转换 Enum
            ChessType tempChess = (ChessType)Enum.Parse(typeof(ChessType), type);
            //由逻辑坐标 --->物理坐标
            int physicsX = x * 40;
            int physicsY = y * 40;

            switch (type)
            {
                case "白子":
                    //绘制五子棋在最基础的画笔上
                    this._gs.DrawImage(_whiteChess, physicsX, physicsY, 40, 40);
                    //isok = false;
                    chessArray[x, y] = (int)tempChess;//白棋
                    this._chess = ChessType.黑子;//下次下棋顺序

                    break;
                case "黑子":
                    this._gs.DrawImage(_blackChess, physicsX, physicsY, 40, 40);
                    //isok = true;
                    this.chessArray[x, y] = (int)tempChess;
                    this._chess = ChessType.白子;
                    break;
                default:
                    break;
            }
        }

        //将文本消息传递到对方
        void writeMessage(string message)
        {
            if (_sw == null)
            {
                return;
            }
            _sw.WriteLine(message);
        }

        
        /// <summary>
        /// 游戏输赢判断
        /// </summary>
        /// <param name="logicX"></param>
        /// <param name="logicY"></param>
        /// <param name="chess"></param>
        /// <param name="e"></param>
        private void GameGudge(int logicX,int logicY,ChessType _chess , MouseEventArgs e)
        {
            string message = "";
            //换手
            //bool handover = true;//服务器先下黑棋
            if (_logicX <= 0 || _logicX >= 14 || _logicY <= 0 || _logicY >= 14)
            {
                return;
            }
            if (chessArray[_logicX, _logicY] == 0)
            {
                
                //左键下棋
                if (e.Button == MouseButtons.Left)
                {
                    ChessType tempChess = this._chess; //保存当前落子类型
                    if (_role == GameRole.擂主)
                    {
                        this._gs.DrawImage(_blackChess, _physicsX, _physicsY, 40, 40);
                        //isok = true;
                        message = string.Format("downchess:{0}|{1}|{2}", _logicX, _logicY, this._chess);
                        chessArray[_logicX, _logicY] = (int)this._chess;//黑棋

                    }
                    else
                    {
                        //绘制五子棋在最基础的画笔上
                        this._gs.DrawImage(_whiteChess, _physicsX, _physicsY, 40, 40);
                        //isok = false;
                        message = string.Format("downchess:{0}|{1}|{2}", _logicX, _logicY, this._chess);
                        chessArray[_logicX, _logicY] = (int)this._chess;//白棋
                    }
                    
                    
                    //判断黑棋白棋是否获胜
                    if (chessArray[_logicX, _logicY] == 1)
                    {
                        int x = _logicX;
                        int y = _logicY;
                        //垂直向上的个数
                        y--;
                        int num = 1;
                        while (chessArray[x, y] == 1)
                        {
                            num++;
                            y--;
                        }
                        //水平向下
                        x = _logicX;
                        y = _logicY;
                        y++;
                        while (y <= 14 && chessArray[x, y] == 1)
                        {
                            num++;
                            y++;
                        }
                        if (num == 5)
                        {
                            MessageBox.Show("白棋获胜");
                            this._rungame = false;
                        }
                        //水平向左
                        x = _logicX;
                        y = _logicY;
                        x--;
                        num = 1;
                        while (chessArray[x, y] == 1)
                        {
                            num++;
                            x--;
                        }
                        //水平向右
                        x = _logicX;
                        y = _logicY;
                        x++;
                        while (chessArray[x, y] == 1)
                        {
                            num++;
                            x++;
                        }
                        if (num == 5)
                        {
                            MessageBox.Show("白棋获胜");
                            this._rungame = false;
                        }
                        //左斜向上
                        x = _logicX;
                        y = _logicY;
                        x--;
                        y--;
                        num = 1;
                        while (chessArray[x, y] == 1)
                        {
                            x--;
                            y--;
                            num++;
                        }
                        //左斜向下
                        x = _logicX;
                        y = _logicY;
                        x++;
                        y++;
                        while (chessArray[x, y] == 1)
                        {
                            x++;
                            y++;
                            num++;
                        }
                        if (num == 5)
                        {
                            MessageBox.Show("白棋获胜");
                            this._rungame = false;
                        }
                        //右斜向上
                        x = _logicX;
                        y = _logicY;
                        x++;
                        y--;
                        num = 1;
                        while (chessArray[x, y] == 1)
                        {
                            x++;
                            y--;
                            num++;
                        }
                        //右斜向下
                        x = _logicX;
                        y = _logicY;
                        x--;
                        y++;
                        while (chessArray[x, y] == 1)
                        {
                            x--;
                            y++;
                            num++;
                        }
                        if (num == 5)
                        {
                            MessageBox.Show("白棋获胜");
                            this._rungame = false;
                        }
                    }
                    else if (chessArray[_logicX, _logicY] == 2)
                    {
                        //判断黑棋是否获胜
                        int x = _logicX;
                        int y = _logicY;
                        //垂直向上的个数
                        y--;
                        int num = 1;
                        while (chessArray[x, y] == 2)
                        {
                            num++;
                            y--;
                        }
                        //水平向下
                        x = _logicX;
                        y = _logicY;
                        y++;
                        while (chessArray[x, y] == 2)
                        {
                            num++;
                            y++;
                        }
                        if (num == 5)
                        {
                            MessageBox.Show("黑棋获胜");
                            this._rungame = false;
                        }
                        //水平向左
                        x = _logicX;
                        y = _logicY;
                        x--;
                        num = 1;
                        while (chessArray[x, y] == 2)
                        {
                            num++;
                            x--;
                        }
                        //水平向右
                        x = _logicX;
                        y = _logicY;
                        x++;
                        while (chessArray[x, y] == 2)
                        {
                            num++;
                            x++;
                        }
                        if (num == 5)
                        {
                            MessageBox.Show("黑棋获胜");
                            this._rungame = false;
                        }
                        //左斜向上
                        x = _logicX;
                        y = _logicY;
                        x--;
                        y--;
                        num = 1;
                        while (chessArray[x, y] == 2)
                        {
                            x--;
                            y--;
                            num++;
                        }
                        //左斜向下
                        x = _logicX;
                        y = _logicY;
                        x++;
                        y++;
                        while (chessArray[x, y] == 2)
                        {
                            x++;
                            y++;
                            num++;
                        }
                        if (num == 5)
                        {
                            MessageBox.Show("黑棋获胜");
                            this._rungame = false;
                        }
                        //右斜向上
                        x = _logicX;
                        y = _logicY;
                        x++;
                        y--;
                        num = 1;
                        while (chessArray[x, y] == 2)
                        {
                            x++;
                            y--;
                            num++;
                        }
                        //右斜向下
                        x = _logicX;
                        y = _logicY;
                        x--;
                        y++;
                        while (chessArray[x, y] == 2)
                        {
                            x--;
                            y++;
                            num++;
                        }
                        if (num == 5)
                        {
                            MessageBox.Show("黑棋获胜");
                            this._rungame = false;
                        }
                    }
                }

            }

            //网络传输
            this.writeMessage(message);

        }
        
        //禁手判断
        private bool chess()
        {
            //if (this.chessArray[_logicX, _logicY] != 0)
            //{
            //    return false;
            //}
            //else
            //{

            //}
            return true;
        }
        
        #region //---------------------- 先手 ----------------------------
        //黑棋
        //private void btnBlick_Click(object sender, EventArgs e)
        //{
        //    //当游戏开始初始化先手
        //    if (this._rungame == false)
        //    {
        //        isok = false;
        //    }
        //}
        ////白棋
        //private void btnWhile_Click(object sender, EventArgs e)
        //{
        //    //当游戏开始初始化先手
        //    if (this._rungame == false)
        //    {
        //        isok = true;
        //    }

        //}
        #endregion


        //单机游戏
        private void tsmiStand_Click(object sender, EventArgs e)
        {
            this._rungame = true;

        }


    }
}
