#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;
using System.IO;
using System.Media;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Threading;
using MetroFramework.Controls;
using System.CodeDom;
using System.Collections;
using System.Configuration;
using System.Deployment;
using System.Dynamic;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Resources;
using System.Runtime;
using System.Security;
using System.Timers;
using System.Web;
using System.Windows;
using System.Xml;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.DesignerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Hosting;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Windows.Markup;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Net.Cache;
using System.Net.Sockets;
using TabControl = System.Windows.Forms.TabControl;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using Perma;
using System.IO.Compression;
using MyMp3Player;
using DiscordRpcDemo;
using Perma.Properties;
using TGASharpLib;
using System.Drawing.Imaging;
#endregion

namespace Perma
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            InitializeComponent();
            _soundPlayer = new SoundPlayer("Welcome.wav");

            #region Update
            WebClient webClient = new WebClient();
            try
            {
                if (webClient.DownloadString("https://pastebin.com/raw/VS2ttjqc").Contains("1.0.0.1"))
                {
                }
                else
                {
                    if (MessageBox.Show("There are a new version of Perma ! Would you like to download it ?", "Perma", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        try
                        {
                            //Directory.CreateDirectory(@"/MamiesMod V2");
                            webClient.DownloadFile("https://nt-games-site.000webhostapp.com/img/Perma.zip", "Perma.zip");
                            ZipFile.ExtractToDirectory("Perma.zip", @"./Update");
                            File.Delete("Perma.zip");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch
            {
                MessageBox.Show("The application can't check if there are a update because you are not connected to internet !", "MamiesMod V3");
            }
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Style Manager
            this.StyleManager = metroStyleManager1;
            //metroStyleManager1.Style = MetroFramework.MetroColorStyle.Teal;
            //this.Refresh();
            #endregion

            #region SoundPlayer
            _soundPlayer.Play();
            #endregion

            #region Language
            language.Text = File.ReadAllText(@"Settings\language.txt");
            if (language.Text == "french")
            {
                Thread.CurrentThread.CurrentUICulture
             = new System.Globalization.CultureInfo("fr");
                this.Controls.Clear();
                InitializeComponent();
                ((System.Windows.Forms.CheckBox)(object)fr).Checked = true;
                ((System.Windows.Forms.CheckBox)(object)en).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)ja).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)de).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)es).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)it).Checked = false;
            }
            if (language.Text == "english")
            {
                ((System.Windows.Forms.CheckBox)(object)fr).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)en).Checked = true;
                ((System.Windows.Forms.CheckBox)(object)ja).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)de).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)es).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)it).Checked = false;
            }
            if (language.Text == "japnese")
            {
                Thread.CurrentThread.CurrentUICulture
             = new System.Globalization.CultureInfo("ja");
                this.Controls.Clear();
                InitializeComponent();
                ((System.Windows.Forms.CheckBox)(object)fr).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)en).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)ja).Checked = true;
                ((System.Windows.Forms.CheckBox)(object)de).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)es).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)it).Checked = false;
                this.handlers = default(DiscordRpc.EventHandlers);
            }
            if (language.Text == "german")
            {
                Thread.CurrentThread.CurrentUICulture
             = new System.Globalization.CultureInfo("de");
                this.Controls.Clear();
                InitializeComponent();
                ((System.Windows.Forms.CheckBox)(object)fr).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)en).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)ja).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)de).Checked = true;
                ((System.Windows.Forms.CheckBox)(object)es).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)it).Checked = false;
            }
            if (language.Text == "spanish")
            {
                Thread.CurrentThread.CurrentUICulture
             = new System.Globalization.CultureInfo("es");
                this.Controls.Clear();
                InitializeComponent();
                ((System.Windows.Forms.CheckBox)(object)fr).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)en).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)ja).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)de).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)es).Checked = true;
                ((System.Windows.Forms.CheckBox)(object)it).Checked = false;
            }
            if (language.Text == "italian")
            {
                Thread.CurrentThread.CurrentUICulture
             = new System.Globalization.CultureInfo("it");
                this.Controls.Clear();
                InitializeComponent();
                ((System.Windows.Forms.CheckBox)(object)fr).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)en).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)ja).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)de).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)es).Checked = false;
                ((System.Windows.Forms.CheckBox)(object)it).Checked = true;
            }
            #endregion

            #region Load Settings
            textBox1.Text = File.ReadAllText(@"Settings\IP.txt");
            comboBox1.Text = File.ReadAllText(@"Settings\Storage.txt");
            comboBox2.Text = File.ReadAllText(@"Settings\Region.txt");
            comboBox4.Text = File.ReadAllText(@"Settings\Theme.txt");
            comboBox3.Text = File.ReadAllText(@"Settings\Style.txt");
            #endregion

            #region Discord Precense
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("799263089152753674", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("799263089152753674", ref this.handlers, true, null);
            this.presence.details = "Perma by nt games";
            this.presence.state = "";
            this.presence.largeImageKey = "perma";
            this.presence.smallImageKey = "minecraft";
            this.presence.largeImageText = "Perma by nt games";
            this.presence.smallImageText = "Minecraft";
            DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long startTimestamp = (long)(DateTime.UtcNow - d).TotalSeconds;
            this.presence.startTimestamp = startTimestamp;
            DiscordRpc.UpdatePresence(ref this.presence);
            #endregion

            #region Can Connect
            if (textBox1.Text != "")
            {
                if (comboBox1.Text != "")
                {
                    if (comboBox2.Text != "")
                    {
                        CanConnect.Checked = true;
                        //settings
                        StreamWriter streamWriterIP = new StreamWriter(@"Settings\IP.txt");
                        streamWriterIP.Write(textBox1.Text);
                        streamWriterIP.Close();
                        StreamWriter streamWriterStorage = new StreamWriter(@"Settings\Storage.txt");
                        streamWriterStorage.Write(comboBox1.Text);
                        streamWriterStorage.Close();
                        StreamWriter streamWriterRegion = new StreamWriter(@"Settings\Region.txt");
                        streamWriterRegion.Write(comboBox2.Text);
                        streamWriterRegion.Close();
                    }
                    else
                    {
                        CanConnect.Checked = false;
                    }
                }
                else
                {
                    CanConnect.Checked = false;
                }
            }
            else
            {
                CanConnect.Checked = false;
            }
            #endregion
        }

        private SoundPlayer _soundPlayer;//welcome
        Random random = new Random();
        private Mp3Player mp3Player = new Mp3Player();//rdm
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        TGA T; 

        #region Style
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox4.SelectedIndex)
            {
                case 0://light
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                    this.Refresh();
                    break;
                case 1://dark
                    metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                    this.Refresh();
                    break;
            }
            StreamWriter streamWriterTheme = new StreamWriter(@"Settings\Theme.txt");
            streamWriterTheme.Write(comboBox4.Text);
            streamWriterTheme.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0://Black
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Black;
                    this.Refresh();
                    break;
                case 1://White
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.White;
                    this.Refresh();
                    break;
                case 2://Silver
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Silver;
                    this.Refresh();
                    break;
                case 3://Blue
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Blue;
                    this.Refresh();
                    break;
                case 4://Green
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Green;
                    this.Refresh();
                    break;
                case 5://Lime
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime;
                    this.Refresh();
                    break;
                case 6://Teal
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Teal;
                    this.Refresh();
                    break;
                case 7://Orange
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Orange;
                    this.Refresh();
                    break;
                case 8://Brown
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Brown;
                    this.Refresh();
                    break;
                case 9://Pink
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Pink;
                    this.Refresh();
                    break;
                case 10://Magenta
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Magenta;
                    this.Refresh();
                    break;
                case 11://Purple
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Purple;
                    this.Refresh();
                    break;
                case 12://Red
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
                    this.Refresh();
                    break;
                case 13://Yellow
                    metroStyleManager1.Style = MetroFramework.MetroColorStyle.Yellow;
                    this.Refresh();
                    break;
            }
            StreamWriter streamWriterStyle = new StreamWriter(@"Settings\Style.txt");
            streamWriterStyle.Write(comboBox3.Text);
            streamWriterStyle.Close();
        }
        #endregion

        #region Music
        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("music");
            FileInfo[] dirFiles = di.GetFiles();
            int posVals = dirFiles.Length;
            int randfile = random.Next(0, posVals);
            string music = dirFiles[randfile].Name;
            //textBox1.Text = @"music\" + music;
            mp3Player.open(@"music\" + music);
            mp3Player.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mp3Player.stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("music");
        }
        #endregion

        #region tabPage Enter
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            if (fr.Checked)
            {
                this.presence.state = "Dans l'acceuil";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (en.Checked)
            {
                this.presence.state = "In home";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (ja.Checked)
            {
                this.presence.state = "自宅で";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (de.Checked)
            {
                this.presence.state = "Zuhause";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (es.Checked)
            {
                this.presence.state = "A casa";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (it.Checked)
            {
                this.presence.state = "A casa";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            if (fr.Checked)
            {
                this.presence.state = "Dans skin";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (en.Checked)
            {
                this.presence.state = "In skin";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (ja.Checked)
            {
                this.presence.state = "肌に";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (de.Checked)
            {
                this.presence.state = "Im skin";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (es.Checked)
            {
                this.presence.state = "En skin";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (it.Checked)
            {
                this.presence.state = "In skin";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
        }

        private void tabPage7_Enter(object sender, EventArgs e)
        {
            if (fr.Checked)
            {
                this.presence.state = "Dans texture pack";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (en.Checked)
            {
                this.presence.state = "In texture pack";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (ja.Checked)
            {
                this.presence.state = "テクスチャパックで";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (de.Checked)
            {
                this.presence.state = "Im Texturpaket";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (es.Checked)
            {
                this.presence.state = "En paquete de textura";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (it.Checked)
            {
                this.presence.state = "In confezione texture";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
        }

        private void tabPage8_Enter(object sender, EventArgs e)
        {
            if (fr.Checked)
            {
                this.presence.state = "Dans musique";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (en.Checked)
            {
                this.presence.state = "In musique";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (ja.Checked)
            {
                this.presence.state = "音楽で";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (de.Checked)
            {
                this.presence.state = "In Musik";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (es.Checked)
            {
                this.presence.state = "En musica";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (it.Checked)
            {
                this.presence.state = "Nella musica";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
        }

        private void tabPage9_Enter(object sender, EventArgs e)
        {
            if (fr.Checked)
            {
                this.presence.state = "Dans mini-jeux";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (en.Checked)
            {
                this.presence.state = "In minigames";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (ja.Checked)
            {
                this.presence.state = "ミニゲームで";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (de.Checked)
            {
                this.presence.state = "In Minispielen";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (es.Checked)
            {
                this.presence.state = "En minijuegos";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (it.Checked)
            {
                this.presence.state = "Nei minigiochi";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
        }

        private void tabPage14_Enter(object sender, EventArgs e)
        {
            if (fr.Checked)
            {
                this.presence.state = "Dans meta";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (en.Checked)
            {
                this.presence.state = "In meta";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (ja.Checked)
            {
                this.presence.state = "メタで";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (de.Checked)
            {
                this.presence.state = "In Meta";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (es.Checked)
            {
                this.presence.state = "En meta";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (it.Checked)
            {
                this.presence.state = "In meta";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
        }

        private void tabPage10_Enter(object sender, EventArgs e)
        {
            if (fr.Checked)
            {
                this.presence.state = "Dans autre";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (en.Checked)
            {
                this.presence.state = "In other";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (ja.Checked)
            {
                this.presence.state = "その他";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (de.Checked)
            {
                this.presence.state = "In anderen";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (es.Checked)
            {
                this.presence.state = "En otra";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            if (it.Checked)
            {
                this.presence.state = "In altro";
                DiscordRpc.UpdatePresence(ref this.presence);
            }
        }
        #endregion

        #region Discord
        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/28v7SkwwP9");
            //MaximizeBox = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/nk22HmUDJC");
            //MaximizeBox = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/xe2tj6J");
            //MinimizeBox = false;
        }
        #endregion

        #region My channel
        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCqI3x47OlUfndU3b9VhAwwQ?view_as=subscriber");
        }
        #endregion

        #region MamiesMod
        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://youtu.be/quYxuZn-RXs");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://youtu.be/IFmxsHjj9qM");
        }
        #endregion

        #region Language
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox5.SelectedIndex)
            {
                case 0://english
                    Thread.CurrentThread.CurrentUICulture
                 = new System.Globalization.CultureInfo("en");
                    this.Controls.Clear();
                    InitializeComponent();
                    ((System.Windows.Forms.CheckBox)(object)fr).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)en).Checked = true;
                    ((System.Windows.Forms.CheckBox)(object)ja).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)de).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)es).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)it).Checked = false;
                    //comboBox5.Text = "English";
                    break;
                case 1://french
                    Thread.CurrentThread.CurrentUICulture
                 = new System.Globalization.CultureInfo("fr");
                    this.Controls.Clear();
                    InitializeComponent();
                    ((System.Windows.Forms.CheckBox)(object)fr).Checked = true;
                    ((System.Windows.Forms.CheckBox)(object)en).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)ja).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)de).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)es).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)it).Checked = false;
                    //comboBox5.Text = "Français";
                    break;
                case 2://japness
                    Thread.CurrentThread.CurrentUICulture
                 = new System.Globalization.CultureInfo("ja");
                    this.Controls.Clear();
                    InitializeComponent();
                    ((System.Windows.Forms.CheckBox)(object)fr).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)en).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)ja).Checked = true;
                    ((System.Windows.Forms.CheckBox)(object)de).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)es).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)it).Checked = false;
                    //comboBox5.Text = "日本人";
                    break;
                case 3://german
                    Thread.CurrentThread.CurrentUICulture
                 = new System.Globalization.CultureInfo("de");
                    this.Controls.Clear();
                    InitializeComponent();
                    ((System.Windows.Forms.CheckBox)(object)fr).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)en).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)ja).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)de).Checked = true;
                    ((System.Windows.Forms.CheckBox)(object)es).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)it).Checked = false;
                    //comboBox5.Text = "Deutsche";
                    break;
                case 4://spanish
                    Thread.CurrentThread.CurrentUICulture
                 = new System.Globalization.CultureInfo("es");
                    this.Controls.Clear();
                    InitializeComponent();
                    ((System.Windows.Forms.CheckBox)(object)fr).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)en).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)ja).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)de).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)es).Checked = true;
                    ((System.Windows.Forms.CheckBox)(object)it).Checked = false;
                    //comboBox5.Text = "Español";
                    break;
                case 5://italian
                    Thread.CurrentThread.CurrentUICulture
                 = new System.Globalization.CultureInfo("it");
                    this.Controls.Clear();
                    InitializeComponent();
                    ((System.Windows.Forms.CheckBox)(object)fr).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)en).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)ja).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)de).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)es).Checked = false;
                    ((System.Windows.Forms.CheckBox)(object)it).Checked = true;
                    //comboBox5.Text = "Italiano";
                    break;
            }
        }

        private void fr_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(@"Settings\language.txt");
            streamWriter.Write("french");
            streamWriter.Close();
        }

        private void en_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(@"Settings\language.txt");
            streamWriter.Write("english");
            streamWriter.Close();
        }

        private void ja_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(@"Settings\language.txt");
            streamWriter.Write("japnese");
            streamWriter.Close();
        }

        private void de_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(@"Settings\language.txt");
            streamWriter.Write("german");
            streamWriter.Close();
        }

        private void es_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(@"Settings\language.txt");
            streamWriter.Write("spanish");
            streamWriter.Close();
        }

        private void it_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(@"Settings\language.txt");
            streamWriter.Write("italian");
            streamWriter.Close();
        }
        #endregion

        #region Settings
        private void CanConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (CanConnect.Checked)
            {
                button42.Enabled = true;
                button32.Enabled = true;
                button106.Enabled = true;
                button117.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button40.Enabled = true;
                button36.Enabled = true;
                button38.Enabled = true;
                button50.Enabled = true;
                button54.Enabled = true;
                button53.Enabled = true;
                button52.Enabled = true;
                button51.Enabled = true;
                button45.Enabled = true;
                button44.Enabled = true;
                button43.Enabled = true;
                button66.Enabled = true;
                button70.Enabled = true;
                button69.Enabled = true;
                button68.Enabled = true;
                button67.Enabled = true;
                button61.Enabled = true;
                button60.Enabled = true;
                button59.Enabled = true;
                button82.Enabled = true;
                button86.Enabled = true;
                button85.Enabled = true;
                button84.Enabled = true;
                button83.Enabled = true;
                button77.Enabled = true;
                button76.Enabled = true;
                button75.Enabled = true;
                button89.Enabled = true;
                button90.Enabled = true;
                button17.Enabled = true;
                button19.Enabled = true;
                button18.Enabled = true;
                button28.Enabled = true;
                button30.Enabled = true;
                button29.Enabled = true;
                button100.Enabled = true;
                button104.Enabled = true;
                button103.Enabled = true;
                button102.Enabled = true;
                button101.Enabled = true;
                button95.Enabled = true;
                button94.Enabled = true;
                button109.Enabled = true;
                button111.Enabled = true;
                button110.Enabled = true;
                button114.Enabled = true;
                button116.Enabled = true;
                button131.Enabled = true;
                button134.Enabled = true;
                button133.Enabled = true;
                button132.Enabled = true;
                button126.Enabled = true;
            }
            else
            {
                button42.Enabled = false;
                button32.Enabled = false;
                button106.Enabled = false;
                button117.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button40.Enabled = false;
                button36.Enabled = false;
                button38.Enabled = false;
                button50.Enabled = false;
                button54.Enabled = false;
                button53.Enabled = false;
                button52.Enabled = false;
                button51.Enabled = false;
                button45.Enabled = false;
                button44.Enabled = false;
                button43.Enabled = false;
                button66.Enabled = false;
                button70.Enabled = false;
                button69.Enabled = false;
                button68.Enabled = false;
                button67.Enabled = false;
                button61.Enabled = false;
                button60.Enabled = false;
                button59.Enabled = false;
                button82.Enabled = false;
                button86.Enabled = false;
                button85.Enabled = false;
                button84.Enabled = false;
                button83.Enabled = false;
                button77.Enabled = false;
                button76.Enabled = false;
                button75.Enabled = false;
                button89.Enabled = false;
                button90.Enabled = false;
                button17.Enabled = false;
                button19.Enabled = false;
                button18.Enabled = false;
                button28.Enabled = false;
                button30.Enabled = false;
                button29.Enabled = false;
                button100.Enabled = false;
                button104.Enabled = false;
                button103.Enabled = false;
                button102.Enabled = false;
                button101.Enabled = false;
                button95.Enabled = false;
                button94.Enabled = false;
                button109.Enabled = false;
                button111.Enabled = false;
                button110.Enabled = false;
                button114.Enabled = false;
                button116.Enabled = false;
                button131.Enabled = false;
                button134.Enabled = false;
                button133.Enabled = false;
                button132.Enabled = false;
                button126.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (comboBox1.Text != "")
                {
                    if (comboBox2.Text != "")
                    {
                        CanConnect.Checked = true;
                        //settings
                        StreamWriter streamWriterIP = new StreamWriter(@"Settings\IP.txt");
                        streamWriterIP.Write(textBox1.Text);
                        streamWriterIP.Close();
                        StreamWriter streamWriterStorage = new StreamWriter(@"Settings\Storage.txt");
                        streamWriterStorage.Write(comboBox1.Text);
                        streamWriterStorage.Close();
                        StreamWriter streamWriterRegion = new StreamWriter(@"Settings\Region.txt");
                        streamWriterRegion.Write(comboBox2.Text);
                        streamWriterRegion.Close();
                    }
                    else
                    {
                        CanConnect.Checked = false;
                    }
                }
                else
                {
                    CanConnect.Checked = false;
                }
            }
            else
            {
                CanConnect.Checked = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (comboBox1.Text != "")
                {
                    if (comboBox2.Text != "")
                    {
                        CanConnect.Checked = true;
                        //settings
                        StreamWriter streamWriterIP = new StreamWriter(@"Settings\IP.txt");
                        streamWriterIP.Write(textBox1.Text);
                        streamWriterIP.Close();
                        StreamWriter streamWriterStorage = new StreamWriter(@"Settings\Storage.txt");
                        streamWriterStorage.Write(comboBox1.Text);
                        streamWriterStorage.Close();
                        StreamWriter streamWriterRegion = new StreamWriter(@"Settings\Region.txt");
                        streamWriterRegion.Write(comboBox2.Text);
                        streamWriterRegion.Close();
                    }
                    else
                    {
                        CanConnect.Checked = false;
                    }
                }
                else
                {
                    CanConnect.Checked = false;
                }
            }
            else
            {
                CanConnect.Checked = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (comboBox1.Text != "")
                {
                    if (comboBox2.Text != "")
                    {
                        CanConnect.Checked = true;
                        //settings
                        StreamWriter streamWriterIP = new StreamWriter(@"Settings\IP.txt");
                        streamWriterIP.Write(textBox1.Text);
                        streamWriterIP.Close();
                        StreamWriter streamWriterStorage = new StreamWriter(@"Settings\Storage.txt");
                        streamWriterStorage.Write(comboBox1.Text);
                        streamWriterStorage.Close();
                        StreamWriter streamWriterRegion = new StreamWriter(@"Settings\Region.txt");
                        streamWriterRegion.Write(comboBox2.Text);
                        streamWriterRegion.Close();
                    }
                    else
                    {
                        CanConnect.Checked = false;
                    }
                }
                else
                {
                    CanConnect.Checked = false;
                }
            }
            else
            {
                CanConnect.Checked = false;
            }
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (comboBox1.Text != "")
                {
                    if (comboBox2.Text != "")
                    {
                        CanConnect.Checked = true;
                        //settings
                        StreamWriter streamWriterIP = new StreamWriter(@"Settings\IP.txt");
                        streamWriterIP.Write(textBox1.Text);
                        streamWriterIP.Close();
                        StreamWriter streamWriterStorage = new StreamWriter(@"Settings\Storage.txt");
                        streamWriterStorage.Write(comboBox1.Text);
                        streamWriterStorage.Close();
                        StreamWriter streamWriterRegion = new StreamWriter(@"Settings\Region.txt");
                        streamWriterRegion.Write(comboBox2.Text);
                        streamWriterRegion.Close();
                    }
                    else
                    {
                        CanConnect.Checked = false;
                    }
                }
                else
                {
                    CanConnect.Checked = false;
                }
            }
            else
            {
                CanConnect.Checked = false;
            }
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (comboBox1.Text != "")
                {
                    if (comboBox2.Text != "")
                    {
                        CanConnect.Checked = true;
                        //settings
                        StreamWriter streamWriterIP = new StreamWriter(@"Settings\IP.txt");
                        streamWriterIP.Write(textBox1.Text);
                        streamWriterIP.Close();
                        StreamWriter streamWriterStorage = new StreamWriter(@"Settings\Storage.txt");
                        streamWriterStorage.Write(comboBox1.Text);
                        streamWriterStorage.Close();
                        StreamWriter streamWriterRegion = new StreamWriter(@"Settings\Region.txt");
                        streamWriterRegion.Write(comboBox2.Text);
                        streamWriterRegion.Close();
                    }
                    else
                    {
                        CanConnect.Checked = false;
                    }
                }
                else
                {
                    CanConnect.Checked = false;
                }
            }
            else
            {
                CanConnect.Checked = false;
            }
        }
        #endregion

        #region Method
        private void uploadFile(string filePath)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://" + textBox1.Text + "/" + storage.Text + "/usr/title/" + app.Text + "/" + region.Text + "/" + chemin.Text + "/" + Path.GetFileName(filePath));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            FileStream stream = File.OpenRead(filePath);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();
        }

        private void downloadFile()
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://" + textBox1.Text + "/" + storage.Text + "/usr/title/" + app.Text + "/" + region.Text + "/" + chemin.Text + file.Text);
            request.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            FileStream writer = new FileStream(@"Download\" + file.Text, FileMode.Create);

            long length = response.ContentLength;
            int bufferSize = 2048;
            int readCount;
            byte[] buffer = new byte[2048];

            readCount = responseStream.Read(buffer, 0, bufferSize);
            while (readCount > 0)
            {
                writer.Write(buffer, 0, readCount);
                readCount = responseStream.Read(buffer, 0, bufferSize);
            }

            responseStream.Close();
            response.Close();
            writer.Close();
        }

        private void downloadFileDrWho()
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://" + textBox1.Text + "/" + storage.Text + "/usr/title/" + app.Text + "/" + region.Text + "/" + chemin.Text + file.Text);
            request.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            FileStream writer = new FileStream(@"Download\SkinPackDrWho2.pck", FileMode.Create);

            long length = response.ContentLength;
            int bufferSize = 2048;
            int readCount;
            byte[] buffer = new byte[2048];

            readCount = responseStream.Read(buffer, 0, bufferSize);
            while (readCount > 0)
            {
                writer.Write(buffer, 0, readCount);
                readCount = responseStream.Read(buffer, 0, bufferSize);
            }

            responseStream.Close();
            response.Close();
            writer.Close();
        }
        #endregion

        #region Skin

        #region Change
        private void button42_Click(object sender, EventArgs e)//CHANGE
        {
            if (fr.Checked)
            {
                if (MessageBox.Show("Êtes-vous sur de vouloir changer les skins ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    downloadText.Text = "Téléchargement : Installation en cours (0%)";
                    string downloadPourcentage = "Téléchargement : Installation en cours";
                    progressBar1.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //chemin.Text = @"content\WiiU\DLC\";
                    //Upload des fichiers
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Battle & Beasts\";
                        uploadFile(@"Upload\BattleAndBeasts.pck");
                        File.Delete(@"Upload\BattleAndBeasts.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Battle & Beasts 2\";
                        uploadFile(@"Upload\BattleAndBeasts2.pck");
                        File.Delete(@"Upload\BattleAndBeasts2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Biome Settlers Pack 1\";
                        uploadFile(@"Upload\SkinsBiomeSettlers1.pck");
                        File.Delete(@"Upload\SkinsBiomeSettlers1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Biome Settlers Pack 2\";
                        uploadFile(@"Upload\SkinsBiomeSettlers2.pck");
                        File.Delete(@"Upload\SkinsBiomeSettlers2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Campfire Tales Skin Pack\";
                        uploadFile(@"Upload\CampfireTales.pck");
                        File.Delete(@"Upload\CampfireTales.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Doctor Who Skins Volume I\";
                        uploadFile(@"Upload\SkinPackDrWho.pck");
                        File.Delete(@"Upload\SkinPackDrWho.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        File.Move(@"Upload\SkinPackDrWho2.pck", @"Upload\SkinPackDrWho.pck");
                        chemin.Text = chemin.Text + @"Doctor Who Skins Volume II\";
                        uploadFile(@"Upload\SkinPackDrWho.pck");
                        File.Delete(@"Upload\SkinPackDrWho.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Festive Skin Pack\";
                        uploadFile(@"Upload\SkinsFestive.pck");
                        File.Delete(@"Upload\SkinsFestive.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"FINAL FANTASY XV Skin Pack\";
                        uploadFile(@"Upload\FinalFantasyXV.pck");
                        File.Delete(@"Upload\FinalFantasyXV.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"From The Shadows Skin Pack\";
                        uploadFile(@"Upload\FromTheShadows.pck");
                        File.Delete(@"Upload\FromTheShadows.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Magic The Gathering Skin Pack\";
                        uploadFile(@"Upload\magicthegathering.pck");
                        File.Delete(@"Upload\magicthegathering.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Mini Game Heroes Skin Pack\";
                        uploadFile(@"Upload\Minigame2.pck");
                        File.Delete(@"Upload\Minigame2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Mini Game Masters Skin Pack\";
                        uploadFile(@"Upload\Minigame.pck");
                        File.Delete(@"Upload\Minigame.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Moana Character Pack\";
                        uploadFile(@"Upload\Moana.pck");
                        File.Delete(@"Upload\Moana.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Power Rangers Skin Pack\";
                        uploadFile(@"Upload\PowerRangers.pck");
                        File.Delete(@"Upload\PowerRangers.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Redstone Specialists Skin Pack\";
                        uploadFile(@"Upload\SkinsRedstoneSpecialists.pck");
                        File.Delete(@"Upload\SkinsRedstoneSpecialists.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 1\";
                        uploadFile(@"Upload\Skins1.pck");
                        File.Delete(@"Upload\Skins1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 2\";
                        uploadFile(@"Upload\Skins2.pck");
                        File.Delete(@"Upload\Skins2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 3\";
                        uploadFile(@"Upload\Skins3.pck");
                        File.Delete(@"Upload\Skins3.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"From The Shadows Skin Pack\";
                        uploadFile(@"Upload\FromTheShadows.pck");
                        File.Delete(@"Upload\FromTheShadows.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Solo A Star Wars Story Pack\";
                        uploadFile(@"Upload\Solo.pck");
                        File.Delete(@"Upload\Solo.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Classic Skin Pack\";
                        uploadFile(@"Upload\StarWarsClassicPack.pck");
                        File.Delete(@"Upload\StarWarsClassicPack.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Prequel Skin Pack\";
                        uploadFile(@"Upload\StarWarsPrequel.pck");
                        File.Delete(@"Upload\StarWarsPrequel.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Rebels Skin Pack\";
                        uploadFile(@"Upload\StarWarsRebelsPackpck");
                        File.Delete(@"Upload\StarWarsRebelsPack.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Sequel Skin Pack\";
                        uploadFile(@"Upload\StarWarsSequel.pck");
                        File.Delete(@"Upload\StarWarsSequel.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Story Mode Skin Pack\";
                        uploadFile(@"Upload\PackStoryMode.pck");
                        File.Delete(@"Upload\PackStoryMode.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Stranger Things Skin Pack\";
                        uploadFile(@"Upload\StrangerThings.pck");
                        File.Delete(@"Upload\StrangerThings.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Strangers Biome Settlers 3 Skin Pack\";
                        uploadFile(@"Upload\BiomeSettlers3_Strangers.pck");
                        File.Delete(@"Upload\BiomeSettlers3_Strangers.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"The Incredibles Skin Pack\";
                        uploadFile(@"Upload\Incredibles.pck");
                        File.Delete(@"Upload\Incredibles.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"The Simpsons Skin Pack\";
                        uploadFile(@"Upload\SkinPackSimpsons.pck");
                        File.Delete(@"Upload\SkinPackSimpsons.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Villains Skin Pack\";
                        uploadFile(@"Upload\Villains.pck");
                        File.Delete(@"Upload\Villains.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //spécial skin
                    //chemin.Text = @"content\WiiU\CU\DLC\";
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"1st Birthday Skin Pack\";
                        uploadFile(@"Upload\WiiUSkinsBirthday1.pck");
                        File.Delete(@"Upload\WiiUSkinsBirthday1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"2nd Birthday Skin Pack\";
                        uploadFile(@"Upload\Pack2ndBirthday.pck");
                        File.Delete(@"Upload\Pack2ndBirthday.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"Minecon 2016 Skin Pack\";
                        uploadFile(@"Upload\SkinsMinecon2016.pck");
                        File.Delete(@"Upload\SkinsMinecon2016.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"Minecon Earth 2017\";
                        uploadFile(@"Upload\SkinsMineconEarth2017.pck");
                        File.Delete(@"Upload\SkinsMineconEarth2017.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    downloadText.Text = "Téléchargement : Installation réussie ! (100%)";
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                { }
            }
            if (en.Checked)
            {
                if (MessageBox.Show("Are you sure you want to change the skins ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    downloadText.Text = "Download : Installation in progress (0%)";
                    string downloadPourcentage = "Download: Installation in progress";
                    progressBar1.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //chemin.Text = @"content\WiiU\DLC\";
                    //Upload des fichiers
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Battle & Beasts\";
                        uploadFile(@"Upload\BattleAndBeasts.pck");
                        File.Delete(@"Upload\BattleAndBeasts.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Battle & Beasts 2\";
                        uploadFile(@"Upload\BattleAndBeasts2.pck");
                        File.Delete(@"Upload\BattleAndBeasts2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Biome Settlers Pack 1\";
                        uploadFile(@"Upload\SkinsBiomeSettlers1.pck");
                        File.Delete(@"Upload\SkinsBiomeSettlers1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Biome Settlers Pack 2\";
                        uploadFile(@"Upload\SkinsBiomeSettlers2.pck");
                        File.Delete(@"Upload\SkinsBiomeSettlers2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Campfire Tales Skin Pack\";
                        uploadFile(@"Upload\CampfireTales.pck");
                        File.Delete(@"Upload\CampfireTales.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Doctor Who Skins Volume I\";
                        uploadFile(@"Upload\SkinPackDrWho.pck");
                        File.Delete(@"Upload\SkinPackDrWho.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        File.Move(@"Upload\SkinPackDrWho2.pck", @"Upload\SkinPackDrWho.pck");
                        chemin.Text = chemin.Text + @"Doctor Who Skins Volume II\";
                        uploadFile(@"Upload\SkinPackDrWho.pck");
                        File.Delete(@"Upload\SkinPackDrWho.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Festive Skin Pack\";
                        uploadFile(@"Upload\SkinsFestive.pck");
                        File.Delete(@"Upload\SkinsFestive.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"FINAL FANTASY XV Skin Pack\";
                        uploadFile(@"Upload\FinalFantasyXV.pck");
                        File.Delete(@"Upload\FinalFantasyXV.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"From The Shadows Skin Pack\";
                        uploadFile(@"Upload\FromTheShadows.pck");
                        File.Delete(@"Upload\FromTheShadows.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Magic The Gathering Skin Pack\";
                        uploadFile(@"Upload\magicthegathering.pck");
                        File.Delete(@"Upload\magicthegathering.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Mini Game Heroes Skin Pack\";
                        uploadFile(@"Upload\Minigame2.pck");
                        File.Delete(@"Upload\Minigame2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Mini Game Masters Skin Pack\";
                        uploadFile(@"Upload\Minigame.pck");
                        File.Delete(@"Upload\Minigame.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Moana Character Pack\";
                        uploadFile(@"Upload\Moana.pck");
                        File.Delete(@"Upload\Moana.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Power Rangers Skin Pack\";
                        uploadFile(@"Upload\PowerRangers.pck");
                        File.Delete(@"Upload\PowerRangers.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Redstone Specialists Skin Pack\";
                        uploadFile(@"Upload\SkinsRedstoneSpecialists.pck");
                        File.Delete(@"Upload\SkinsRedstoneSpecialists.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 1\";
                        uploadFile(@"Upload\Skins1.pck");
                        File.Delete(@"Upload\Skins1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 2\";
                        uploadFile(@"Upload\Skins2.pck");
                        File.Delete(@"Upload\Skins2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 3\";
                        uploadFile(@"Upload\Skins3.pck");
                        File.Delete(@"Upload\Skins3.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"From The Shadows Skin Pack\";
                        uploadFile(@"Upload\FromTheShadows.pck");
                        File.Delete(@"Upload\FromTheShadows.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Solo A Star Wars Story Pack\";
                        uploadFile(@"Upload\Solo.pck");
                        File.Delete(@"Upload\Solo.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Classic Skin Pack\";
                        uploadFile(@"Upload\StarWarsClassicPack.pck");
                        File.Delete(@"Upload\StarWarsClassicPack.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Prequel Skin Pack\";
                        uploadFile(@"Upload\StarWarsPrequel.pck");
                        File.Delete(@"Upload\StarWarsPrequel.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Rebels Skin Pack\";
                        uploadFile(@"Upload\StarWarsRebelsPackpck");
                        File.Delete(@"Upload\StarWarsRebelsPack.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Sequel Skin Pack\";
                        uploadFile(@"Upload\StarWarsSequel.pck");
                        File.Delete(@"Upload\StarWarsSequel.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Story Mode Skin Pack\";
                        uploadFile(@"Upload\PackStoryMode.pck");
                        File.Delete(@"Upload\PackStoryMode.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Stranger Things Skin Pack\";
                        uploadFile(@"Upload\StrangerThings.pck");
                        File.Delete(@"Upload\StrangerThings.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Strangers Biome Settlers 3 Skin Pack\";
                        uploadFile(@"Upload\BiomeSettlers3_Strangers.pck");
                        File.Delete(@"Upload\BiomeSettlers3_Strangers.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"The Incredibles Skin Pack\";
                        uploadFile(@"Upload\Incredibles.pck");
                        File.Delete(@"Upload\Incredibles.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"The Simpsons Skin Pack\";
                        uploadFile(@"Upload\SkinPackSimpsons.pck");
                        File.Delete(@"Upload\SkinPackSimpsons.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Villains Skin Pack\";
                        uploadFile(@"Upload\Villains.pck");
                        File.Delete(@"Upload\Villains.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //spécial skin
                    //chemin.Text = @"content\WiiU\CU\DLC\";
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"1st Birthday Skin Pack\";
                        uploadFile(@"Upload\WiiUSkinsBirthday1.pck");
                        File.Delete(@"Upload\WiiUSkinsBirthday1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"2nd Birthday Skin Pack\";
                        uploadFile(@"Upload\Pack2ndBirthday.pck");
                        File.Delete(@"Upload\Pack2ndBirthday.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"Minecon 2016 Skin Pack\";
                        uploadFile(@"Upload\SkinsMinecon2016.pck");
                        File.Delete(@"Upload\SkinsMinecon2016.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"Minecon Earth 2017\";
                        uploadFile(@"Upload\SkinsMineconEarth2017.pck");
                        File.Delete(@"Upload\SkinsMineconEarth2017.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    downloadText.Text = "Download : Installation successful ! (100%)";
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                { }
            }
            if (ja.Checked)
            {
                if (MessageBox.Show("スキンを変更してもよろしいですか ？", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    downloadText.Text = "ダウンロード：インストール中 (0%)";
                    string downloadPourcentage = "ダウンロード：インストール中";
                    progressBar1.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //chemin.Text = @"content\WiiU\DLC\";
                    //Upload des fichiers
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Battle & Beasts\";
                        uploadFile(@"Upload\BattleAndBeasts.pck");
                        File.Delete(@"Upload\BattleAndBeasts.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Battle & Beasts 2\";
                        uploadFile(@"Upload\BattleAndBeasts2.pck");
                        File.Delete(@"Upload\BattleAndBeasts2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Biome Settlers Pack 1\";
                        uploadFile(@"Upload\SkinsBiomeSettlers1.pck");
                        File.Delete(@"Upload\SkinsBiomeSettlers1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Biome Settlers Pack 2\";
                        uploadFile(@"Upload\SkinsBiomeSettlers2.pck");
                        File.Delete(@"Upload\SkinsBiomeSettlers2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Campfire Tales Skin Pack\";
                        uploadFile(@"Upload\CampfireTales.pck");
                        File.Delete(@"Upload\CampfireTales.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Doctor Who Skins Volume I\";
                        uploadFile(@"Upload\SkinPackDrWho.pck");
                        File.Delete(@"Upload\SkinPackDrWho.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        File.Move(@"Upload\SkinPackDrWho2.pck", @"Upload\SkinPackDrWho.pck");
                        chemin.Text = chemin.Text + @"Doctor Who Skins Volume II\";
                        uploadFile(@"Upload\SkinPackDrWho.pck");
                        File.Delete(@"Upload\SkinPackDrWho.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Festive Skin Pack\";
                        uploadFile(@"Upload\SkinsFestive.pck");
                        File.Delete(@"Upload\SkinsFestive.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"FINAL FANTASY XV Skin Pack\";
                        uploadFile(@"Upload\FinalFantasyXV.pck");
                        File.Delete(@"Upload\FinalFantasyXV.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"From The Shadows Skin Pack\";
                        uploadFile(@"Upload\FromTheShadows.pck");
                        File.Delete(@"Upload\FromTheShadows.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Magic The Gathering Skin Pack\";
                        uploadFile(@"Upload\magicthegathering.pck");
                        File.Delete(@"Upload\magicthegathering.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Mini Game Heroes Skin Pack\";
                        uploadFile(@"Upload\Minigame2.pck");
                        File.Delete(@"Upload\Minigame2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Mini Game Masters Skin Pack\";
                        uploadFile(@"Upload\Minigame.pck");
                        File.Delete(@"Upload\Minigame.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Moana Character Pack\";
                        uploadFile(@"Upload\Moana.pck");
                        File.Delete(@"Upload\Moana.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Power Rangers Skin Pack\";
                        uploadFile(@"Upload\PowerRangers.pck");
                        File.Delete(@"Upload\PowerRangers.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Redstone Specialists Skin Pack\";
                        uploadFile(@"Upload\SkinsRedstoneSpecialists.pck");
                        File.Delete(@"Upload\SkinsRedstoneSpecialists.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 1\";
                        uploadFile(@"Upload\Skins1.pck");
                        File.Delete(@"Upload\Skins1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 2\";
                        uploadFile(@"Upload\Skins2.pck");
                        File.Delete(@"Upload\Skins2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 3\";
                        uploadFile(@"Upload\Skins3.pck");
                        File.Delete(@"Upload\Skins3.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"From The Shadows Skin Pack\";
                        uploadFile(@"Upload\FromTheShadows.pck");
                        File.Delete(@"Upload\FromTheShadows.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Solo A Star Wars Story Pack\";
                        uploadFile(@"Upload\Solo.pck");
                        File.Delete(@"Upload\Solo.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Classic Skin Pack\";
                        uploadFile(@"Upload\StarWarsClassicPack.pck");
                        File.Delete(@"Upload\StarWarsClassicPack.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Prequel Skin Pack\";
                        uploadFile(@"Upload\StarWarsPrequel.pck");
                        File.Delete(@"Upload\StarWarsPrequel.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Rebels Skin Pack\";
                        uploadFile(@"Upload\StarWarsRebelsPackpck");
                        File.Delete(@"Upload\StarWarsRebelsPack.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Sequel Skin Pack\";
                        uploadFile(@"Upload\StarWarsSequel.pck");
                        File.Delete(@"Upload\StarWarsSequel.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Story Mode Skin Pack\";
                        uploadFile(@"Upload\PackStoryMode.pck");
                        File.Delete(@"Upload\PackStoryMode.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Stranger Things Skin Pack\";
                        uploadFile(@"Upload\StrangerThings.pck");
                        File.Delete(@"Upload\StrangerThings.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Strangers Biome Settlers 3 Skin Pack\";
                        uploadFile(@"Upload\BiomeSettlers3_Strangers.pck");
                        File.Delete(@"Upload\BiomeSettlers3_Strangers.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"The Incredibles Skin Pack\";
                        uploadFile(@"Upload\Incredibles.pck");
                        File.Delete(@"Upload\Incredibles.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"The Simpsons Skin Pack\";
                        uploadFile(@"Upload\SkinPackSimpsons.pck");
                        File.Delete(@"Upload\SkinPackSimpsons.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Villains Skin Pack\";
                        uploadFile(@"Upload\Villains.pck");
                        File.Delete(@"Upload\Villains.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //spécial skin
                    //chemin.Text = @"content\WiiU\CU\DLC\";
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"1st Birthday Skin Pack\";
                        uploadFile(@"Upload\WiiUSkinsBirthday1.pck");
                        File.Delete(@"Upload\WiiUSkinsBirthday1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"2nd Birthday Skin Pack\";
                        uploadFile(@"Upload\Pack2ndBirthday.pck");
                        File.Delete(@"Upload\Pack2ndBirthday.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"Minecon 2016 Skin Pack\";
                        uploadFile(@"Upload\SkinsMinecon2016.pck");
                        File.Delete(@"Upload\SkinsMinecon2016.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"Minecon Earth 2017\";
                        uploadFile(@"Upload\SkinsMineconEarth2017.pck");
                        File.Delete(@"Upload\SkinsMineconEarth2017.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    downloadText.Text = "Tダウンロード：インストールに成功しました！ (100%)";
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                { }
            }
            if (de.Checked)
            {
                if (MessageBox.Show("Möchten Sie die Skins wirklich ändern ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    downloadText.Text = "Download : Installation läuft(0%)";
                    string downloadPourcentage = "Download : Installation läuft";
                    progressBar1.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //chemin.Text = @"content\WiiU\DLC\";
                    //Upload des fichiers
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Battle & Beasts\";
                        uploadFile(@"Upload\BattleAndBeasts.pck");
                        File.Delete(@"Upload\BattleAndBeasts.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Battle & Beasts 2\";
                        uploadFile(@"Upload\BattleAndBeasts2.pck");
                        File.Delete(@"Upload\BattleAndBeasts2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Biome Settlers Pack 1\";
                        uploadFile(@"Upload\SkinsBiomeSettlers1.pck");
                        File.Delete(@"Upload\SkinsBiomeSettlers1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Biome Settlers Pack 2\";
                        uploadFile(@"Upload\SkinsBiomeSettlers2.pck");
                        File.Delete(@"Upload\SkinsBiomeSettlers2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Campfire Tales Skin Pack\";
                        uploadFile(@"Upload\CampfireTales.pck");
                        File.Delete(@"Upload\CampfireTales.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Doctor Who Skins Volume I\";
                        uploadFile(@"Upload\SkinPackDrWho.pck");
                        File.Delete(@"Upload\SkinPackDrWho.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        File.Move(@"Upload\SkinPackDrWho2.pck", @"Upload\SkinPackDrWho.pck");
                        chemin.Text = chemin.Text + @"Doctor Who Skins Volume II\";
                        uploadFile(@"Upload\SkinPackDrWho.pck");
                        File.Delete(@"Upload\SkinPackDrWho.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Festive Skin Pack\";
                        uploadFile(@"Upload\SkinsFestive.pck");
                        File.Delete(@"Upload\SkinsFestive.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"FINAL FANTASY XV Skin Pack\";
                        uploadFile(@"Upload\FinalFantasyXV.pck");
                        File.Delete(@"Upload\FinalFantasyXV.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"From The Shadows Skin Pack\";
                        uploadFile(@"Upload\FromTheShadows.pck");
                        File.Delete(@"Upload\FromTheShadows.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Magic The Gathering Skin Pack\";
                        uploadFile(@"Upload\magicthegathering.pck");
                        File.Delete(@"Upload\magicthegathering.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Mini Game Heroes Skin Pack\";
                        uploadFile(@"Upload\Minigame2.pck");
                        File.Delete(@"Upload\Minigame2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Mini Game Masters Skin Pack\";
                        uploadFile(@"Upload\Minigame.pck");
                        File.Delete(@"Upload\Minigame.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Moana Character Pack\";
                        uploadFile(@"Upload\Moana.pck");
                        File.Delete(@"Upload\Moana.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Power Rangers Skin Pack\";
                        uploadFile(@"Upload\PowerRangers.pck");
                        File.Delete(@"Upload\PowerRangers.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Redstone Specialists Skin Pack\";
                        uploadFile(@"Upload\SkinsRedstoneSpecialists.pck");
                        File.Delete(@"Upload\SkinsRedstoneSpecialists.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 1\";
                        uploadFile(@"Upload\Skins1.pck");
                        File.Delete(@"Upload\Skins1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 2\";
                        uploadFile(@"Upload\Skins2.pck");
                        File.Delete(@"Upload\Skins2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 3\";
                        uploadFile(@"Upload\Skins3.pck");
                        File.Delete(@"Upload\Skins3.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"From The Shadows Skin Pack\";
                        uploadFile(@"Upload\FromTheShadows.pck");
                        File.Delete(@"Upload\FromTheShadows.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Solo A Star Wars Story Pack\";
                        uploadFile(@"Upload\Solo.pck");
                        File.Delete(@"Upload\Solo.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Classic Skin Pack\";
                        uploadFile(@"Upload\StarWarsClassicPack.pck");
                        File.Delete(@"Upload\StarWarsClassicPack.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Prequel Skin Pack\";
                        uploadFile(@"Upload\StarWarsPrequel.pck");
                        File.Delete(@"Upload\StarWarsPrequel.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Rebels Skin Pack\";
                        uploadFile(@"Upload\StarWarsRebelsPackpck");
                        File.Delete(@"Upload\StarWarsRebelsPack.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Sequel Skin Pack\";
                        uploadFile(@"Upload\StarWarsSequel.pck");
                        File.Delete(@"Upload\StarWarsSequel.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Story Mode Skin Pack\";
                        uploadFile(@"Upload\PackStoryMode.pck");
                        File.Delete(@"Upload\PackStoryMode.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Stranger Things Skin Pack\";
                        uploadFile(@"Upload\StrangerThings.pck");
                        File.Delete(@"Upload\StrangerThings.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Strangers Biome Settlers 3 Skin Pack\";
                        uploadFile(@"Upload\BiomeSettlers3_Strangers.pck");
                        File.Delete(@"Upload\BiomeSettlers3_Strangers.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"The Incredibles Skin Pack\";
                        uploadFile(@"Upload\Incredibles.pck");
                        File.Delete(@"Upload\Incredibles.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"The Simpsons Skin Pack\";
                        uploadFile(@"Upload\SkinPackSimpsons.pck");
                        File.Delete(@"Upload\SkinPackSimpsons.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Villains Skin Pack\";
                        uploadFile(@"Upload\Villains.pck");
                        File.Delete(@"Upload\Villains.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //spécial skin
                    //chemin.Text = @"content\WiiU\CU\DLC\";
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"1st Birthday Skin Pack\";
                        uploadFile(@"Upload\WiiUSkinsBirthday1.pck");
                        File.Delete(@"Upload\WiiUSkinsBirthday1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"2nd Birthday Skin Pack\";
                        uploadFile(@"Upload\Pack2ndBirthday.pck");
                        File.Delete(@"Upload\Pack2ndBirthday.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"Minecon 2016 Skin Pack\";
                        uploadFile(@"Upload\SkinsMinecon2016.pck");
                        File.Delete(@"Upload\SkinsMinecon2016.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"Minecon Earth 2017\";
                        uploadFile(@"Upload\SkinsMineconEarth2017.pck");
                        File.Delete(@"Upload\SkinsMineconEarth2017.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    downloadText.Text = "Download : Installation erfolgreich! (100%)";
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                { }
            }
            if (es.Checked)
            {
                if (MessageBox.Show("¿Estás seguro de que quieres cambiar las máscaras?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    downloadText.Text = "Descarga : instalación en curso(0%)";
                    string downloadPourcentage = "Descarga : instalación en curso";
                    progressBar1.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //chemin.Text = @"content\WiiU\DLC\";
                    //Upload des fichiers
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Battle & Beasts\";
                        uploadFile(@"Upload\BattleAndBeasts.pck");
                        File.Delete(@"Upload\BattleAndBeasts.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Battle & Beasts 2\";
                        uploadFile(@"Upload\BattleAndBeasts2.pck");
                        File.Delete(@"Upload\BattleAndBeasts2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Biome Settlers Pack 1\";
                        uploadFile(@"Upload\SkinsBiomeSettlers1.pck");
                        File.Delete(@"Upload\SkinsBiomeSettlers1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Biome Settlers Pack 2\";
                        uploadFile(@"Upload\SkinsBiomeSettlers2.pck");
                        File.Delete(@"Upload\SkinsBiomeSettlers2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Campfire Tales Skin Pack\";
                        uploadFile(@"Upload\CampfireTales.pck");
                        File.Delete(@"Upload\CampfireTales.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Doctor Who Skins Volume I\";
                        uploadFile(@"Upload\SkinPackDrWho.pck");
                        File.Delete(@"Upload\SkinPackDrWho.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        File.Move(@"Upload\SkinPackDrWho2.pck", @"Upload\SkinPackDrWho.pck");
                        chemin.Text = chemin.Text + @"Doctor Who Skins Volume II\";
                        uploadFile(@"Upload\SkinPackDrWho.pck");
                        File.Delete(@"Upload\SkinPackDrWho.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Festive Skin Pack\";
                        uploadFile(@"Upload\SkinsFestive.pck");
                        File.Delete(@"Upload\SkinsFestive.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"FINAL FANTASY XV Skin Pack\";
                        uploadFile(@"Upload\FinalFantasyXV.pck");
                        File.Delete(@"Upload\FinalFantasyXV.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"From The Shadows Skin Pack\";
                        uploadFile(@"Upload\FromTheShadows.pck");
                        File.Delete(@"Upload\FromTheShadows.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Magic The Gathering Skin Pack\";
                        uploadFile(@"Upload\magicthegathering.pck");
                        File.Delete(@"Upload\magicthegathering.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Mini Game Heroes Skin Pack\";
                        uploadFile(@"Upload\Minigame2.pck");
                        File.Delete(@"Upload\Minigame2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Mini Game Masters Skin Pack\";
                        uploadFile(@"Upload\Minigame.pck");
                        File.Delete(@"Upload\Minigame.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Moana Character Pack\";
                        uploadFile(@"Upload\Moana.pck");
                        File.Delete(@"Upload\Moana.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Power Rangers Skin Pack\";
                        uploadFile(@"Upload\PowerRangers.pck");
                        File.Delete(@"Upload\PowerRangers.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Redstone Specialists Skin Pack\";
                        uploadFile(@"Upload\SkinsRedstoneSpecialists.pck");
                        File.Delete(@"Upload\SkinsRedstoneSpecialists.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 1\";
                        uploadFile(@"Upload\Skins1.pck");
                        File.Delete(@"Upload\Skins1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 2\";
                        uploadFile(@"Upload\Skins2.pck");
                        File.Delete(@"Upload\Skins2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 3\";
                        uploadFile(@"Upload\Skins3.pck");
                        File.Delete(@"Upload\Skins3.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"From The Shadows Skin Pack\";
                        uploadFile(@"Upload\FromTheShadows.pck");
                        File.Delete(@"Upload\FromTheShadows.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Solo A Star Wars Story Pack\";
                        uploadFile(@"Upload\Solo.pck");
                        File.Delete(@"Upload\Solo.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Classic Skin Pack\";
                        uploadFile(@"Upload\StarWarsClassicPack.pck");
                        File.Delete(@"Upload\StarWarsClassicPack.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Prequel Skin Pack\";
                        uploadFile(@"Upload\StarWarsPrequel.pck");
                        File.Delete(@"Upload\StarWarsPrequel.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Rebels Skin Pack\";
                        uploadFile(@"Upload\StarWarsRebelsPackpck");
                        File.Delete(@"Upload\StarWarsRebelsPack.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Sequel Skin Pack\";
                        uploadFile(@"Upload\StarWarsSequel.pck");
                        File.Delete(@"Upload\StarWarsSequel.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Story Mode Skin Pack\";
                        uploadFile(@"Upload\PackStoryMode.pck");
                        File.Delete(@"Upload\PackStoryMode.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Stranger Things Skin Pack\";
                        uploadFile(@"Upload\StrangerThings.pck");
                        File.Delete(@"Upload\StrangerThings.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Strangers Biome Settlers 3 Skin Pack\";
                        uploadFile(@"Upload\BiomeSettlers3_Strangers.pck");
                        File.Delete(@"Upload\BiomeSettlers3_Strangers.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"The Incredibles Skin Pack\";
                        uploadFile(@"Upload\Incredibles.pck");
                        File.Delete(@"Upload\Incredibles.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"The Simpsons Skin Pack\";
                        uploadFile(@"Upload\SkinPackSimpsons.pck");
                        File.Delete(@"Upload\SkinPackSimpsons.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Villains Skin Pack\";
                        uploadFile(@"Upload\Villains.pck");
                        File.Delete(@"Upload\Villains.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //spécial skin
                    //chemin.Text = @"content\WiiU\CU\DLC\";
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"1st Birthday Skin Pack\";
                        uploadFile(@"Upload\WiiUSkinsBirthday1.pck");
                        File.Delete(@"Upload\WiiUSkinsBirthday1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"2nd Birthday Skin Pack\";
                        uploadFile(@"Upload\Pack2ndBirthday.pck");
                        File.Delete(@"Upload\Pack2ndBirthday.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"Minecon 2016 Skin Pack\";
                        uploadFile(@"Upload\SkinsMinecon2016.pck");
                        File.Delete(@"Upload\SkinsMinecon2016.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"Minecon Earth 2017\";
                        uploadFile(@"Upload\SkinsMineconEarth2017.pck");
                        File.Delete(@"Upload\SkinsMineconEarth2017.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    downloadText.Text = "Descarga : ¡Instalación exitosa! (100%)";
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                { }
            }
            if (it.Checked)
            {
                if (MessageBox.Show("Sei sicuro di voler cambiare le skin ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    downloadText.Text = "Download : installazione in corso (0%)";
                    string downloadPourcentage = "Download : installazione in corso";
                    progressBar1.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //chemin.Text = @"content\WiiU\DLC\";
                    //Upload des fichiers
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Battle & Beasts\";
                        uploadFile(@"Upload\BattleAndBeasts.pck");
                        File.Delete(@"Upload\BattleAndBeasts.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Battle & Beasts 2\";
                        uploadFile(@"Upload\BattleAndBeasts2.pck");
                        File.Delete(@"Upload\BattleAndBeasts2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Biome Settlers Pack 1\";
                        uploadFile(@"Upload\SkinsBiomeSettlers1.pck");
                        File.Delete(@"Upload\SkinsBiomeSettlers1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Biome Settlers Pack 2\";
                        uploadFile(@"Upload\SkinsBiomeSettlers2.pck");
                        File.Delete(@"Upload\SkinsBiomeSettlers2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Campfire Tales Skin Pack\";
                        uploadFile(@"Upload\CampfireTales.pck");
                        File.Delete(@"Upload\CampfireTales.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Doctor Who Skins Volume I\";
                        uploadFile(@"Upload\SkinPackDrWho.pck");
                        File.Delete(@"Upload\SkinPackDrWho.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        File.Move(@"Upload\SkinPackDrWho2.pck", @"Upload\SkinPackDrWho.pck");
                        chemin.Text = chemin.Text + @"Doctor Who Skins Volume II\";
                        uploadFile(@"Upload\SkinPackDrWho.pck");
                        File.Delete(@"Upload\SkinPackDrWho.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Festive Skin Pack\";
                        uploadFile(@"Upload\SkinsFestive.pck");
                        File.Delete(@"Upload\SkinsFestive.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"FINAL FANTASY XV Skin Pack\";
                        uploadFile(@"Upload\FinalFantasyXV.pck");
                        File.Delete(@"Upload\FinalFantasyXV.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"From The Shadows Skin Pack\";
                        uploadFile(@"Upload\FromTheShadows.pck");
                        File.Delete(@"Upload\FromTheShadows.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Magic The Gathering Skin Pack\";
                        uploadFile(@"Upload\magicthegathering.pck");
                        File.Delete(@"Upload\magicthegathering.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Mini Game Heroes Skin Pack\";
                        uploadFile(@"Upload\Minigame2.pck");
                        File.Delete(@"Upload\Minigame2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Mini Game Masters Skin Pack\";
                        uploadFile(@"Upload\Minigame.pck");
                        File.Delete(@"Upload\Minigame.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Moana Character Pack\";
                        uploadFile(@"Upload\Moana.pck");
                        File.Delete(@"Upload\Moana.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Power Rangers Skin Pack\";
                        uploadFile(@"Upload\PowerRangers.pck");
                        File.Delete(@"Upload\PowerRangers.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Redstone Specialists Skin Pack\";
                        uploadFile(@"Upload\SkinsRedstoneSpecialists.pck");
                        File.Delete(@"Upload\SkinsRedstoneSpecialists.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 1\";
                        uploadFile(@"Upload\Skins1.pck");
                        File.Delete(@"Upload\Skins1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 2\";
                        uploadFile(@"Upload\Skins2.pck");
                        File.Delete(@"Upload\Skins2.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Skin Pack 3\";
                        uploadFile(@"Upload\Skins3.pck");
                        File.Delete(@"Upload\Skins3.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"From The Shadows Skin Pack\";
                        uploadFile(@"Upload\FromTheShadows.pck");
                        File.Delete(@"Upload\FromTheShadows.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Solo A Star Wars Story Pack\";
                        uploadFile(@"Upload\Solo.pck");
                        File.Delete(@"Upload\Solo.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Classic Skin Pack\";
                        uploadFile(@"Upload\StarWarsClassicPack.pck");
                        File.Delete(@"Upload\StarWarsClassicPack.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Prequel Skin Pack\";
                        uploadFile(@"Upload\StarWarsPrequel.pck");
                        File.Delete(@"Upload\StarWarsPrequel.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Rebels Skin Pack\";
                        uploadFile(@"Upload\StarWarsRebelsPackpck");
                        File.Delete(@"Upload\StarWarsRebelsPack.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Star Wars Sequel Skin Pack\";
                        uploadFile(@"Upload\StarWarsSequel.pck");
                        File.Delete(@"Upload\StarWarsSequel.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Story Mode Skin Pack\";
                        uploadFile(@"Upload\PackStoryMode.pck");
                        File.Delete(@"Upload\PackStoryMode.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Stranger Things Skin Pack\";
                        uploadFile(@"Upload\StrangerThings.pck");
                        File.Delete(@"Upload\StrangerThings.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Strangers Biome Settlers 3 Skin Pack\";
                        uploadFile(@"Upload\BiomeSettlers3_Strangers.pck");
                        File.Delete(@"Upload\BiomeSettlers3_Strangers.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"The Incredibles Skin Pack\";
                        uploadFile(@"Upload\Incredibles.pck");
                        File.Delete(@"Upload\Incredibles.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"The Simpsons Skin Pack\";
                        uploadFile(@"Upload\SkinPackSimpsons.pck");
                        File.Delete(@"Upload\SkinPackSimpsons.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\";
                        chemin.Text = chemin.Text + @"Villains Skin Pack\";
                        uploadFile(@"Upload\Villains.pck");
                        File.Delete(@"Upload\Villains.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //spécial skin
                    //chemin.Text = @"content\WiiU\CU\DLC\";
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"1st Birthday Skin Pack\";
                        uploadFile(@"Upload\WiiUSkinsBirthday1.pck");
                        File.Delete(@"Upload\WiiUSkinsBirthday1.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"2nd Birthday Skin Pack\";
                        uploadFile(@"Upload\Pack2ndBirthday.pck");
                        File.Delete(@"Upload\Pack2ndBirthday.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"Minecon 2016 Skin Pack\";
                        uploadFile(@"Upload\SkinsMinecon2016.pck");
                        File.Delete(@"Upload\SkinsMinecon2016.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\CU\DLC\";
                        chemin.Text = chemin.Text + @"Minecon Earth 2017\";
                        uploadFile(@"Upload\SkinsMineconEarth2017.pck");
                        File.Delete(@"Upload\SkinsMineconEarth2017.pck");
                        progressBar1.Value = progressBar1.Value + 1;
                        int pourcentage = progressBar1.Value * 100 / progressBar1.Maximum;
                        downloadText.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    downloadText.Text = "Download : installazione riuscita ! (100%)";
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                { }
            }
        }
        #endregion

        private void button10_Click(object sender, EventArgs e)
        {
            //Skin Pack Battle & Beasts
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Battle & Beasts\";
            file.Text = "BattleAndBeasts.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox2.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\BattleAndBeasts.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\BattleAndBeasts.pck");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Battle & Beasts 2\";
            file.Text = "BattleAndBeasts2.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox3.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\BattleAndBeasts2.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\BattleAndBeasts2.pck");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Biome Settlers Pack 1\";
            file.Text = "SkinsBiomeSettlers1.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox4.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\SkinsBiomeSettlers1.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\SkinsBiomeSettlers1.pck");
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Biome Settlers Pack 2\";
            file.Text = "SkinsBiomeSettlers2.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox5.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\SkinsBiomeSettlers2.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\SkinsBiomeSettlers2.pck");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Campfire Tales Skin Pack\";
            file.Text = "CampfireTales.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox6.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\CampfireTales.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\CampfireTales.pck");
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Doctor Who Skins Volume I\";
            file.Text = "SkinPackDrWho.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox17.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\SkinPackDrWho.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\SkinPackDrWho.pck");
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Doctor Who Skins Volume II\";
            file.Text = "SkinPackDrWho.pck";
            try
            {
                downloadFileDrWho();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox16.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\SkinPackDrWho2.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\SkinPackDrWho2.pck");
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Festive Skin Pack\";
            file.Text = "SkinsFestive.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox15.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\SkinsFestive.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\SkinsFestive.pck");
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\FINAL FANTASY XV Skin Pack\";
            file.Text = "FinalFantasyXV.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button55_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox23.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\FinalFantasyXV.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\FinalFantasyXV.pck");
            }
        }

        private void button54_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\From The Shadows Skin Pack\";
            file.Text = "FromTheShadows.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox22.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\FromTheShadows.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\FromTheShadows.pck");
            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Magic The Gathering Skin Pack\";
            file.Text = "magicthegathering.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox21.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\magicthegathering.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\magicthegathering.pck");
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Mini Game Heroes Skin Pack\";
            file.Text = "Minigame2.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox20.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Minigame2.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Minigame2.pck");
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Mini Game Masters Skin Pack\";
            file.Text = "Minigame.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox19.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Minigame.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Minigame.pck");
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Moana Character Pack\";
            file.Text = "Moana.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox18.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Moana.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Moana.pck");
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Power Rangers Skin Pack\";
            file.Text = "PowerRangers.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox14.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\PowerRangers.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\PowerRangers.pck");
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Redstone Specialists Skin Pack\";
            file.Text = "SkinsRedstoneSpecialists.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox13.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\SkinsRedstoneSpecialists.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\SkinsRedstoneSpecialists.pck");
            }
        }

        private void button66_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Skin Pack 1\";
            file.Text = "Skins1.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button71_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox31.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Skins1.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Skins1.pck");
            }
        }

        private void button70_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Skin Pack 2\";
            file.Text = "Skins2.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button65_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox30.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Skins2.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Skins2.pck");
            }
        }

        private void button69_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Skin Pack 3\";
            file.Text = "Skins3.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button64_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox29.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Skins3.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Skins3.pck");
            }
        }

        private void button68_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Solo A Star Wars Story Pack\";
            file.Text = "Solo.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button63_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox28.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Solo.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Solo.pck");
            }
        }

        private void button67_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Star Wars Classic Skin Pack\";
            file.Text = "StarWarsClassicPack.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button62_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox27.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\StarWarsClassicPack.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\StarWarsClassicPack.pck");
            }
        }

        private void button61_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Star Wars Prequel Skin Pack\";
            file.Text = "StarWarsPrequel.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox26.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\StarWarsPrequel.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\StarWarsPrequel.pck");
            }
        }

        private void button60_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Star Wars Rebels Skin Pack\";
            file.Text = "StarWarsRebelsPack.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button57_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox25.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\StarWarsRebelsPack.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\StarWarsRebelsPack.pck");
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Star Wars Sequel Skin Pack\";
            file.Text = "StarWarsSequel.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button56_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox24.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\StarWarsSequel.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\StarWarsSequel.pck");
            }
        }

        private void button82_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Story Mode Skin Pack\";
            file.Text = "PackStoryMode.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button87_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox39.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\PackStoryMode.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\PackStoryMode.pck");
            }
        }

        private void button86_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Stranger Things Skin Pack\";
            file.Text = "StrangerThings.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button81_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox38.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\StrangerThings.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\StrangerThings.pck");
            }
        }

        private void button85_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Strangers Biome Settlers 3 Skin Pack\";
            file.Text = "BiomeSettlers3_Strangers.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button80_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox37.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\BiomeSettlers3_Strangers.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\BiomeSettlers3_Strangers.pck");
            }
        }

        private void button84_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\The Incredibles Skin Pack\";
            file.Text = "Incredibles.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button79_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox36.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Incredibles.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Incredibles.pck");
            }
        }

        private void button83_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\The Simpsons Skin Pack\";
            file.Text = "SkinPackSimpsons.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button78_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox35.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\SkinPackSimpsons.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\SkinPackSimpsons.pck");
            }
        }

        private void button77_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\Villains Skin Pack\";
            file.Text = "Villains.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button74_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox34.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Villains.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Villains.pck");
            }
        }

        private void button76_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\CU\DLC\1st Birthday Skin Pack\";
            file.Text = "WiiUSkinsBirthday1.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button73_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox33.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\WiiUSkinsBirthday1.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\WiiUSkinsBirthday1.pck");
            }
        }

        private void button75_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\CU\DLC\2nd Birthday Skin Pack\";
            file.Text = "Pack2ndBirthday.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button72_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox32.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Pack2ndBirthday.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Pack2ndBirthday.pck");
            }
        }

        private void button89_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\CU\DLC\Minecon 2016 Skin Pack\";
            file.Text = "SkinsMinecon2016.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button91_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox41.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\SkinsMinecon2016.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\SkinsMinecon2016.pck");
            }
        }

        private void button90_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\CU\DLC\Minecon Earth 2017\";
            file.Text = "SkinsMineconEarth2017.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("PCK Téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("PCK Downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("PCK をダウンロード !", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("PCK Heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("PCK Descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("PCK Scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button88_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Skin files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox40.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\SkinsMineconEarth2017.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\SkinsMineconEarth2017.pck");
            }
        }
        #endregion

        #region Texture Pack

        #region Change
        private void button32_Click(object sender, EventArgs e)
        {
            //Directory.CreateDirectory(@"C:\Users\toron\source\repos\Perma\bin\Debug\Upload\" + comboBox6.Text);
            //Directory.CreateDirectory(@"C:\Users\toron\source\repos\Perma\bin\Debug\Upload\" + comboBox6.Text + @"\Data");
            //Directory.CreateDirectory(@"C:\Users\toron\source\repos\Perma\bin\Debug\Upload\" + comboBox7.Text);
            //Directory.CreateDirectory(@"C:\Users\toron\source\repos\Perma\bin\Debug\Upload\" + comboBox7.Text + @"\Data");
            if (fr.Checked)
            {
                if (MessageBox.Show("Êtes-vous sur de vouloir changer les texture pack ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label27.Text = "Téléchargement : Installation en cours (0%)";
                    string downloadPourcentage = "Téléchargement : Installation en cours";
                    progressBar2.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //Upload des fichiers
                    //x16
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //x32
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label27.Text = "Téléchargement : Installation réussie ! (100%)";
                    progressBar2.Value = progressBar2.Maximum;
                }
                else
                { }
            }
            if (en.Checked)
            {
                if (MessageBox.Show("Are you sure you want to change the skins ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label27.Text = "Download : Installation in progress (0%)";
                    string downloadPourcentage = "Download: Installation in progress";
                    progressBar2.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //Upload des fichiers
                    //x16
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //x32
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label27.Text = "Download : Installation successful ! (100%)";
                    progressBar2.Value = progressBar1.Maximum;
                }
                else
                { }
            }
            if (ja.Checked)
            {
                if (MessageBox.Show("テクスチャパックを変更してもよろしいですか ？", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label27.Text = "ダウンロード：インストール中 (0%)";
                    string downloadPourcentage = "ダウンロード：インストール中";
                    progressBar2.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //Upload des fichiers
                    //x16
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //x32
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label27.Text = "Tダウンロード：インストールに成功しました！ (100%)";
                    progressBar2.Value = progressBar1.Maximum;
                }
                else
                { }
            }
            if (de.Checked)
            {
                if (MessageBox.Show("Möchten Sie das Texturpaket wirklich ändern ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label27.Text = "Download : Installation läuft(0%)";
                    string downloadPourcentage = "Download : Installation läuft";
                    progressBar2.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //Upload des fichiers
                    //x16
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //x32
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label27.Text = "Download : Installation erfolgreich! (100%)";
                    progressBar2.Value = progressBar1.Maximum;
                }
                else
                { }
            }
            if (es.Checked)
            {
                if (MessageBox.Show("¿Estás seguro de que quieres cambiar el paquete de texturas?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    downloadText.Text = "Descarga : instalación en curso(0%)";
                    string downloadPourcentage = "Descarga : instalación en curso";
                    progressBar1.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //Upload des fichiers
                    //x16
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //x32
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label27.Text = "Descarga : ¡Instalación exitosa! (100%)";
                    progressBar2.Value = progressBar1.Maximum;
                }
                else
                { }
            }
            if (it.Checked)
            {
                if (MessageBox.Show("Sei sicuro di voler cambiare il pacchetto di texture ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label27.Text = "Download : installazione in corso (0%)";
                    string downloadPourcentage = "Download : installazione in corso";
                    progressBar2.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //Upload des fichiers
                    //x16
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox6.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                        File.Delete(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //x32
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\DLC\" + comboBox7.Text + @"\Data\";
                        uploadFile(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                        File.Delete(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                        progressBar2.Value = progressBar2.Value + 1;
                        int pourcentage = progressBar2.Value * 100 / progressBar2.Maximum;
                        label27.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label27.Text = "Download : installazione riuscita ! (100%)";
                    progressBar2.Value = progressBar1.Maximum;
                }
                else
                {
                    
                }
            }
        }
        #endregion

        private void button17_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\";
            file.Text = comboBox6.Text + @"\TexturePack.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Texture pack files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox9.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\" + comboBox6.Text + @"\TexturePack.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\" + comboBox6.Text + @"\TexturePack.pck");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\";
            file.Text = comboBox6.Text + @"\Data\media.arc";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Archive files (*.arc)|*.arc";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox8.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\" + comboBox6.Text + @"\Data\media.arc");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\" + comboBox6.Text + @"\Data\media.arc");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\";
            file.Text = comboBox6.Text + @"\Data\x16Data.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Texture pack files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox7.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\" + comboBox6.Text + @"\Data\x16Data.pck");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\";
            file.Text = comboBox7.Text + @"\TexturePack.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Texture pack files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox12.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\" + comboBox7.Text + @"\TexturePack.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\" + comboBox7.Text + @"\TexturePack.pck");
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\";
            file.Text = comboBox7.Text + @"\Data\media.arc";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Archive files (*.arc)|*.arc";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox11.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\" + comboBox7.Text + @"\Data\media.arc");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\" + comboBox7.Text + @"\Data\media.arc");
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\DLC\";
            file.Text = comboBox7.Text + @"\Data\x32Data.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Texture pack files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox10.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\" + comboBox7.Text + @"\Data\x32Data.pck");
            }
        }
        #endregion

        #region Meta

        #region Change
        private void button106_Click(object sender, EventArgs e)
        {
            if (fr.Checked)
            {
                if (MessageBox.Show("Êtes-vous sur de vouloir changer les meta ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label62.Text = "Téléchargement : Installation en cours (0%)";
                    string downloadPourcentage = "Téléchargement : Installation en cours";
                    progressBar3.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    chemin.Text = @"meta\";
                    //Upload des fichiers
                    try
                    {
                        uploadFile(@"Upload\bootDrcTex.tga");
                        File.Delete(@"Upload\bootDrcTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootLogoTex.tga");
                        File.Delete(@"Upload\bootLogoTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootSound.btsnd");
                        File.Delete(@"Upload\bootSound.btsnd");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootTvTex.tga");
                        File.Delete(@"Upload\bootTvTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\iconTex.tga");
                        File.Delete(@"Upload\iconTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\Manual.bfma");
                        File.Delete(@"Upload\Manual.bfma");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\meta.xml");
                        File.Delete(@"Upload\meta.xml");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label62.Text = "Téléchargement : Installation réussie ! (100%)";
                    progressBar3.Value = progressBar3.Maximum;
                }
                else
                { }
            }
            if (en.Checked)
            {
                if (MessageBox.Show("Are you sure you want to change the meta ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label62.Text = "Download : Installation in progress (0%)";
                    string downloadPourcentage = "Download: Installation in progress";
                    progressBar3.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    chemin.Text = @"meta\";
                    //Upload des fichiers
                    try
                    {
                        uploadFile(@"Upload\bootDrcTex.tga");
                        File.Delete(@"Upload\bootDrcTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootLogoTex.tga");
                        File.Delete(@"Upload\bootLogoTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootSound.btsnd");
                        File.Delete(@"Upload\bootSound.btsnd");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootTvTex.tga");
                        File.Delete(@"Upload\bootTvTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\iconTex.tga");
                        File.Delete(@"Upload\iconTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\Manual.bfma");
                        File.Delete(@"Upload\Manual.bfma");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\meta.xml");
                        File.Delete(@"Upload\meta.xml");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label62.Text = "Download : Installation successful ! (100%)";
                    progressBar3.Value = progressBar3.Maximum;
                }
                else
                { }
            }
            if (ja.Checked)
            {
                if (MessageBox.Show("メタを変更してもよろしいですか ？", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label62.Text = "ダウンロード：インストール中 (0%)";
                    string downloadPourcentage = "ダウンロード：インストール中";
                    progressBar3.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    chemin.Text = @"meta\";
                    //Upload des fichiers
                    try
                    {
                        uploadFile(@"Upload\bootDrcTex.tga");
                        File.Delete(@"Upload\bootDrcTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootLogoTex.tga");
                        File.Delete(@"Upload\bootLogoTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootSound.btsnd");
                        File.Delete(@"Upload\bootSound.btsnd");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootTvTex.tga");
                        File.Delete(@"Upload\bootTvTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\iconTex.tga");
                        File.Delete(@"Upload\iconTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\Manual.bfma");
                        File.Delete(@"Upload\Manual.bfma");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\meta.xml");
                        File.Delete(@"Upload\meta.xml");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label62.Text = "Tダウンロード：インストールに成功しました！ (100%)";
                    progressBar3.Value = progressBar3.Maximum;
                }
                else
                { }
            }
            if (de.Checked)
            {
                if (MessageBox.Show("Sind Sie sicher, dass Sie das Meta ändern möchten ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label62.Text = "Download : Installation läuft(0%)";
                    string downloadPourcentage = "Download : Installation läuft";
                    progressBar3.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    chemin.Text = @"meta\";
                    //Upload des fichiers
                    try
                    {
                        uploadFile(@"Upload\bootDrcTex.tga");
                        File.Delete(@"Upload\bootDrcTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootLogoTex.tga");
                        File.Delete(@"Upload\bootLogoTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootSound.btsnd");
                        File.Delete(@"Upload\bootSound.btsnd");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootTvTex.tga");
                        File.Delete(@"Upload\bootTvTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\iconTex.tga");
                        File.Delete(@"Upload\iconTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\Manual.bfma");
                        File.Delete(@"Upload\Manual.bfma");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\meta.xml");
                        File.Delete(@"Upload\meta.xml");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label62.Text = "Download : Installation erfolgreich! (100%)";
                    progressBar3.Value = progressBar3.Maximum;
                }
                else
                { }
            }
            if (es.Checked)
            {
                if (MessageBox.Show("¿¿Estás seguro de que quieres cambiar el meta??", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label62.Text = "Descarga : instalación en curso(0%)";
                    string downloadPourcentage = "Descarga : instalación en curso";
                    progressBar3.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    chemin.Text = @"meta\";
                    //Upload des fichiers
                    try
                    {
                        uploadFile(@"Upload\bootDrcTex.tga");
                        File.Delete(@"Upload\bootDrcTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootLogoTex.tga");
                        File.Delete(@"Upload\bootLogoTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootSound.btsnd");
                        File.Delete(@"Upload\bootSound.btsnd");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootTvTex.tga");
                        File.Delete(@"Upload\bootTvTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\iconTex.tga");
                        File.Delete(@"Upload\iconTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\Manual.bfma");
                        File.Delete(@"Upload\Manual.bfma");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\meta.xml");
                        File.Delete(@"Upload\meta.xml");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label62.Text = "Descarga : ¡Instalación exitosa! (100%)";
                    progressBar3.Value = progressBar3.Maximum;
                }
                else
                { }
            }
            if (it.Checked)
            {
                if (MessageBox.Show("Sei sicuro di voler cambiare il meta ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label62.Text = "Download : installazione in corso (0%)";
                    string downloadPourcentage = "Download : installazione in corso";
                    progressBar3.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    chemin.Text = @"meta\";
                    //Upload des fichiers
                    try
                    {
                        uploadFile(@"Upload\bootDrcTex.tga");
                        File.Delete(@"Upload\bootDrcTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootLogoTex.tga");
                        File.Delete(@"Upload\bootLogoTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootSound.btsnd");
                        File.Delete(@"Upload\bootSound.btsnd");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\bootTvTex.tga");
                        File.Delete(@"Upload\bootTvTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\iconTex.tga");
                        File.Delete(@"Upload\iconTex.tga");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\Manual.bfma");
                        File.Delete(@"Upload\Manual.bfma");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\meta.xml");
                        File.Delete(@"Upload\meta.xml");
                        progressBar3.Value = progressBar3.Value + 1;
                        int pourcentage = progressBar3.Value * 100 / progressBar3.Maximum;
                        label62.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label62.Text = "Download : installazione riuscita ! (100%)";
                    progressBar3.Value = progressBar3.Maximum;
                }
                else
                {

                }
            }
        }
        #endregion

        private void button100_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"meta\";
            file.Text = "bootDrcTex.tga";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button105_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.tga)|*.tga";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox48.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\bootDrcTex.tga");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\bootDrcTex.tga");
            }
        }

        private void button104_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"meta\";
            file.Text = "bootLogoTex.tga";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button99_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.tga)|*.tga";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox47.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\bootLogoTex.tga");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\bootLogoTex.tga");
            }
        }

        private void button103_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"meta\";
            file.Text = "bootSound.btsnd";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button98_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Wii U sound files (*.btsnd)|*.btsnd";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox46.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\bootSound.btsnd");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\bootSound.btsnd");
            }
        }

        private void button102_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"meta\";
            file.Text = "bootTvTex.tga";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button97_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.tga)|*.tga";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox45.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\bootTvTex.tga");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\bootTvTex.tga");
            }
        }

        private void button101_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"meta\";
            file.Text = "iconTex.tga";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button96_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.tga)|*.tga";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox44.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\iconTex.tga");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\iconTex.tga");
            }
        }

        private void button95_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"meta\";
            file.Text = "Manual.bfma";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button93_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Wii U manual files (*.bfma)|*.bfma";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox43.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Manual.bfma");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Manual.bfma");
            }
        }

        private void button94_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"meta\";
            file.Text = "meta.xml";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button92_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Xml files (*.xml)|*.xml";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox42.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\meta.xml");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\meta.xml");
            }
        }
        #endregion

        #region Other

        #region Change
        private void button117_Click(object sender, EventArgs e)
        {
            if (fr.Checked)
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir modifier les autres fichiers ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label69.Text = "Téléchargement : Installation en cours (0%)";
                    string downloadPourcentage = "Téléchargement : Installation en cours";
                    progressBar4.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //Upload des fichiers
                    try
                    {
                        chemin.Text = @"code\";
                        uploadFile(@"Upload\Minecraft.Client.rpx");
                        File.Delete(@"Upload\Minecraft.Client.rpx");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\Common\Media\";
                        uploadFile(@"Upload\MediaWiiU.arc");
                        File.Delete(@"Upload\MediaWiiU.arc");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Sound\";
                        uploadFile(@"Upload\Minecraft.msscmp");
                        File.Delete(@"Upload\Minecraft.msscmp");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Tutorial\";
                        uploadFile(@"Upload\Tutorial.mcs");
                        File.Delete(@"Upload\Tutorial.mcs");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Tutorial\";
                        uploadFile(@"Upload\Tutorial.pck");
                        File.Delete(@"Upload\Tutorial.pck");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label69.Text = "Téléchargement : Installation réussie ! (100%)";
                    progressBar4.Value = progressBar4.Maximum;
                }
                else
                { }
            }
            if (en.Checked)
            {
                if (MessageBox.Show("Are you sure you want to change the other files ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label69.Text = "Download : Installation in progress (0%)";
                    string downloadPourcentage = "Download: Installation in progress";
                    progressBar4.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //Upload des fichiers
                    try
                    {
                        chemin.Text = @"code\";
                        uploadFile(@"Upload\Minecraft.Client.rpx");
                        File.Delete(@"Upload\Minecraft.Client.rpx");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\Common\Media\";
                        uploadFile(@"Upload\MediaWiiU.arc");
                        File.Delete(@"Upload\MediaWiiU.arc");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Sound";
                        uploadFile(@"Upload\Minecraft.msscmp");
                        File.Delete(@"Upload\Minecraft.msscmp");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Tutorial\";
                        uploadFile(@"Upload\Tutorial.mcs");
                        File.Delete(@"Upload\Tutorial.mcs");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Tutorial\";
                        uploadFile(@"Upload\Tutorial.pck");
                        File.Delete(@"Upload\Tutorial.pck");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label69.Text = "Download : Installation successful ! (100%)";
                    progressBar4.Value = progressBar4.Maximum;
                }
                else
                { }
            }
            if (ja.Checked)
            {
                if (MessageBox.Show("他のファイルを変更してもよろしいですか ？", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label69.Text = "ダウンロード：インストール中 (0%)";
                    string downloadPourcentage = "ダウンロード：インストール中";
                    progressBar4.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //Upload des fichiers
                    try
                    {
                        chemin.Text = @"code\";
                        uploadFile(@"Upload\Minecraft.Client.rpx");
                        File.Delete(@"Upload\Minecraft.Client.rpx");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\Common\Media\";
                        uploadFile(@"Upload\MediaWiiU.arc");
                        File.Delete(@"Upload\MediaWiiU.arc");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Sound";
                        uploadFile(@"Upload\Minecraft.msscmp");
                        File.Delete(@"Upload\Minecraft.msscmp");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Tutorial\";
                        uploadFile(@"Upload\Tutorial.mcs");
                        File.Delete(@"Upload\Tutorial.mcs");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Tutorial\";
                        uploadFile(@"Upload\Tutorial.pck");
                        File.Delete(@"Upload\Tutorial.pck");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label69.Text = "Tダウンロード：インストールに成功しました！ (100%)";
                    progressBar4.Value = progressBar4.Maximum;
                }
                else
                { }
            }
            if (de.Checked)
            {
                if (MessageBox.Show("Sind Sie sicher, dass Sie die anderen Dateien ändern möchten ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label69.Text = "Download : Installation läuft(0%)";
                    string downloadPourcentage = "Download : Installation läuft";
                    progressBar4.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //Upload des fichiers
                    try
                    {
                        chemin.Text = @"code\";
                        uploadFile(@"Upload\Minecraft.Client.rpx");
                        File.Delete(@"Upload\Minecraft.Client.rpx");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\Common\Media\";
                        uploadFile(@"Upload\MediaWiiU.arc");
                        File.Delete(@"Upload\MediaWiiU.arc");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Sound";
                        uploadFile(@"Upload\Minecraft.msscmp");
                        File.Delete(@"Upload\Minecraft.msscmp");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Tutorial\";
                        uploadFile(@"Upload\Tutorial.mcs");
                        File.Delete(@"Upload\Tutorial.mcs");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Tutorial\";
                        uploadFile(@"Upload\Tutorial.pck");
                        File.Delete(@"Upload\Tutorial.pck");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label69.Text = "Download : Installation erfolgreich! (100%)";
                    progressBar4.Value = progressBar4.Maximum;
                }
                else
                { }
            }
            if (es.Checked)
            {
                if (MessageBox.Show("¿Estás seguro de que quieres cambiar los otros archivos?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label69.Text = "Descarga : instalación en curso(0%)";
                    string downloadPourcentage = "Descarga : instalación en curso";
                    progressBar4.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //Upload des fichiers
                    try
                    {
                        chemin.Text = @"code\";
                        uploadFile(@"Upload\Minecraft.Client.rpx");
                        File.Delete(@"Upload\Minecraft.Client.rpx");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\Common\Media\";
                        uploadFile(@"Upload\MediaWiiU.arc");
                        File.Delete(@"Upload\MediaWiiU.arc");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Sound";
                        uploadFile(@"Upload\Minecraft.msscmp");
                        File.Delete(@"Upload\Minecraft.msscmp");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Tutorial\";
                        uploadFile(@"Upload\Tutorial.mcs");
                        File.Delete(@"Upload\Tutorial.mcs");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Tutorial\";
                        uploadFile(@"Upload\Tutorial.pck");
                        File.Delete(@"Upload\Tutorial.pck");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label69.Text = "Descarga : ¡Instalación exitosa! (100%)";
                    progressBar4.Value = progressBar4.Maximum;
                }
                else
                { }
            }
            if (it.Checked)
            {
                if (MessageBox.Show("Sei sicuro di voler cambiare gli altri file ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label69.Text = "Download : installazione in corso (0%)";
                    string downloadPourcentage = "Download : installazione in corso";
                    progressBar4.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    //Upload des fichiers
                    try
                    {
                        chemin.Text = @"code\";
                        uploadFile(@"Upload\Minecraft.Client.rpx");
                        File.Delete(@"Upload\Minecraft.Client.rpx");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\Common\Media\";
                        uploadFile(@"Upload\MediaWiiU.arc");
                        File.Delete(@"Upload\MediaWiiU.arc");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Sound";
                        uploadFile(@"Upload\Minecraft.msscmp");
                        File.Delete(@"Upload\Minecraft.msscmp");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Tutorial\";
                        uploadFile(@"Upload\Tutorial.mcs");
                        File.Delete(@"Upload\Tutorial.mcs");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        chemin.Text = @"content\WiiU\Tutorial\";
                        uploadFile(@"Upload\Tutorial.pck");
                        File.Delete(@"Upload\Tutorial.pck");
                        progressBar4.Value = progressBar4.Value + 1;
                        int pourcentage = progressBar4.Value * 100 / progressBar4.Maximum;
                        label69.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label69.Text = "Download : installazione riuscita ! (100%)";
                    progressBar4.Value = progressBar4.Maximum;
                }
                else
                {

                }
            }
        }
        #endregion

        private void button109_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"code\";
            file.Text = "Minecraft.Client.rpx";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button112_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Wii U game files (*.rpx)|*.rpx";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox51.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Minecraft.Client.rpx");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Minecraft.Client.rpx");
            }
        }

        private void button111_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\Common\Media\";
            file.Text = "MediaWiiU.arc";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button108_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Archives files (*.arc)|*.arc";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox50.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\MediaWiiU.arc");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\MediaWiiU.arc");
            }
        }

        private void button110_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\Sound\";
            file.Text = "Minecraft.msscmp";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button107_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Minecraft sound files (*.msscmp)|*.msscmp";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox49.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Minecraft.msscmp");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Minecraft.msscmp");
            }
        }

        private void button114_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\Tutorial\";
            file.Text = "Tutorial.mcs";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button113_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Minecraft Wii U map files (*.mcs)|*.mcs";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox52.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Tutorial.mcs");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Tutorial.mcs");
            }
        }

        private void button116_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\WiiU\Tutorial\";
            file.Text = "Tutorial.pck";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button115_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Pck files (*.pck)|*.pck";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox53.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\Tutorial.pck");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\Tutorial.pck");
            }
        }
        #endregion

        #region Wii U Application
        private void button118_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string directoryRoot = Directory.GetDirectoryRoot(folderBrowserDialog.SelectedPath);
                    using (WebClient webClient = new WebClient())
                        if (!Directory.Exists(directoryRoot + "/wiiu/apps/"))
                        {
                            Directory.CreateDirectory(directoryRoot + "/wiiu/apps/");
                        }
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/714815457869299745/745679439395946506/apps.zip", directoryRoot + "/wiiu/apps/apps.zip");
                    }
                    string sourceArchiveFileName = directoryRoot + "/wiiu/apps/apps.zip";
                    string destinationDirectoryName = directoryRoot + "/wiiu/apps/temp";
                    ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
                    if (!Directory.Exists(directoryRoot + "/wiiu/apps/MamiesMod V2"))
                    {
                        Directory.Move(directoryRoot + "/wiiu/apps/temp/MamiesMod V2", directoryRoot + "/wiiu/apps/MamiesMod V2");
                    }
                    if (!Directory.Exists(directoryRoot + "/wiiu/apps/homebrew_launcher"))
                    {
                        Directory.Move(directoryRoot + "/wiiu/apps/temp/homebrew_launcher", directoryRoot + "/wiiu/apps/homebrew_launcher");
                    }
                    File.Delete(directoryRoot + "/wiiu/apps/apps.zip");
                    Directory.Delete(directoryRoot + "/wiiu/apps/temp/", recursive: true);
                    if (fr.Checked)
                    {
                        MessageBox.Show("Les applications Wii U ont bien été installée !", "Perma");
                    }
                    if (en.Checked)
                    {
                        MessageBox.Show("Wii U Apps Download !", "Perma");
                    }
                    if (ja.Checked)
                    {
                        MessageBox.Show("Wii Uアプリダウンロード ！", "Perma");
                    }
                    if (de.Checked)
                    {
                        MessageBox.Show("Wii U Apps herunterladen !", "Perma");
                    }
                    if (es.Checked)
                    {
                        MessageBox.Show("¡ Descarga de aplicaciones de Wii U !", "Perma");
                    }
                    if (it.Checked)
                    {
                        MessageBox.Show("Download di app Wii U !", "Perma");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button119_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string directoryRoot = Directory.GetDirectoryRoot(folderBrowserDialog.SelectedPath);
                    using (WebClient webClient = new WebClient())
                        if (!Directory.Exists(directoryRoot + "/wiiu/apps/"))
                        {
                            Directory.CreateDirectory(directoryRoot + "/wiiu/apps/");
                        }
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile("https://cdn.discordapp.com/attachments/714815457869299745/801148740525752400/apps2.zip", directoryRoot + "/wiiu/apps/apps2.zip");
                    }
                    string sourceArchiveFileName = directoryRoot + "/wiiu/apps/apps2.zip";
                    string destinationDirectoryName = directoryRoot + "/wiiu/apps/temp";
                    ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
                    if (!Directory.Exists(directoryRoot + "/wiiu/apps/ftpiiu_everywhere"))
                    {
                        Directory.Move(directoryRoot + "/wiiu/apps/temp/ftpiiu_everywhere", directoryRoot + "/wiiu/apps/ftpiiu_everywhere");
                    }
                    if (!Directory.Exists(directoryRoot + "/wiiu/apps/mocha_fshax"))
                    {
                        Directory.Move(directoryRoot + "/wiiu/apps/temp/mocha_fshax", directoryRoot + "/wiiu/apps/mocha_fshax");
                    }
                    if (!Directory.Exists(directoryRoot + "/wiiu/apps/homebrew_launcher"))
                    {
                        Directory.Move(directoryRoot + "/wiiu/apps/temp/homebrew_launcher", directoryRoot + "/wiiu/apps/homebrew_launcher");
                    }
                    File.Delete(directoryRoot + "/wiiu/apps/apps2.zip");
                    Directory.Delete(directoryRoot + "/wiiu/apps/temp/", recursive: true);
                    if (fr.Checked)
                    {
                        MessageBox.Show("Les applications Wii U ont bien été installée !", "Perma");
                    }
                    if (en.Checked)
                    {
                        MessageBox.Show("Wii U Apps Download !", "Perma");
                    }
                    if (ja.Checked)
                    {
                        MessageBox.Show("Wii Uアプリダウンロード ！", "Perma");
                    }
                    if (de.Checked)
                    {
                        MessageBox.Show("Wii U Apps herunterladen !", "Perma");
                    }
                    if (es.Checked)
                    {
                        MessageBox.Show("¡ Descarga de aplicaciones de Wii U !", "Perma");
                    }
                    if (it.Checked)
                    {
                        MessageBox.Show("Download di app Wii U !", "Perma");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        #endregion

        #region Convert
        private void button120_Click(object sender, EventArgs e)
        {
            string LoopString = " -noLoop";
            string TempBuildPath = @"Convert\";

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Waveform audio files (*.wav)|*.wav";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                try
                {
                    File.Delete(@"Convert\bootSound.btsnd");
                }
                catch
                { }
                string TempSoundPath = @"Convert\bootSound.wav";
                Process start = new Process();
                start.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                start.StartInfo.FileName = @"TOOLDIR\SOX\sox.exe";
                start.StartInfo.Arguments = "\"" + filepath + "\" -b 16 \"" + TempSoundPath + "\" channels 2 rate 48k trim 0 20";
                start.Start();
                start.WaitForExit();
                //Process.Start(@"TOOLDIR\SOX\sox.exe", "\"" + filepath + "\" -b 16 \"" + TempSoundPath + "\" channels 2 rate 48k trim 0 20");
                //MessageBox.Show("a");
                Process start2 = new Process();
                start2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                start2.StartInfo.FileName = @"TOOLDIR\JAR\wav2btsnd.exe";
                start2.StartInfo.Arguments = "-in \"" + TempSoundPath + "\" -out \"" + TempBuildPath + "\\bootSound.btsnd\"" + LoopString;
                start2.Start();
                start2.WaitForExit();
                //Process.Start(@"TOOLDIR\JAR\wav2btsnd.exe", "-in \"" + TempSoundPath + "\" -out \"" + TempBuildPath + "\\bootSound.btsnd\"" + LoopString);
                //MessageBox.Show("b");
                File.Delete(@"Convert\bootSound.wav");
                //MessageBox.Show("c");
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier converti !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File converted !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルが変換されました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei konvertiert !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo convertido !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File convertito !", "Perma");
                }
            }
        }

        private void button121_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Wii U sound files(*.btsnd) | *.btsnd";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                try
                {
                    File.Delete(@"Convert\bootSound.wav");
                }
                catch
                { }
                //File.Copy(fileDialog.FileName, @"Convert\bootSound2.btsnd");
                //string TempSoundPath = @"Convert\bootSound2.btsnd";
                string LoopString = " -makeWav";
                string TempBuildPath = @"Convert\";
                Process start = new Process();
                start.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                start.StartInfo.FileName = @"TOOLDIR\JAR\wav2btsnd.exe";
                start.StartInfo.Arguments = "-in \"" + filepath + "\" -out \"" + TempBuildPath + "\\bootSound2.wav\"" + LoopString;
                start.Start();
                start.WaitForExit();
                //Process.Start(@"TOOLDIR\JAR\wav2btsnd.exe", "-in \"" + TempSoundPath + "\" -out \"" + TempBuildPath + "\\bootSound.wav\"" + LoopString);
                //File.Delete(@"Convert\bootSound2.btsnd");
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier converti !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File converted !", "Perma");
                }
                if (ja.Checked)
                { 
                    MessageBox.Show("ファイルが変換されました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei konvertiert !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo convertido !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File convertito !", "Perma");
                }
            }
        }

        private void button123_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files(*.png) | *.png";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                string filename = fileDialog.SafeFileName;
                string filename2 = System.IO.Path.GetFileNameWithoutExtension(filepath);
                try
                {
                    File.Delete(@"Convert\" + filename2 + ".tga");
                }
                catch
                { }
                using (Bitmap original = new Bitmap(filepath))
                using (Bitmap clone = new Bitmap(original))
                using (Bitmap newbmp = clone.Clone(new Rectangle(0, 0, clone.Width, clone.Height), PixelFormat.Format32bppArgb))
                    T = (TGA)newbmp;
                T.Save(@"Convert\" + filename2 + ".tga");
                //File.Copy(fileDialog.FileName, @"Convert\" + filename);Path.GetFullPath(filename)
                /*string TempImagePath = filepath;
                string TempBuildPath = Path.GetFullPath(@"Convert\");
                Process.Start(@"TOOLDIR\IMG\png2tgacmd.exe", "-i \"" + TempImagePath + "\" -o \"" + TempBuildPath + "\" --width=128 --height=128 --tga-bpp=32 --tga-compression=none");
                //Process.Start(@"TOOLDIR\IMG\png2tgacmd.exe", "-i \"" + TempImagePath + "\" -o \"" + TempBuildPath + "a\" --width=128 --height=128 --tga-bpp=32 --tga-compression=none");//-i \C:\Users\toron\source\repos\Perma\bin\Debug\Convert\iconTest.png\ -o \C:\Users\toron\source\repos\Perma\bin\Debug\Convert\iconTest.tga --tga-compression=none"
                //string test = " - i \"" + TempImagePath + "\" -o \"" + TempBuildPath + "a\" --width=128 --height=128 --tga-bpp=32 --tga-compression=none";
                MessageBox.Show("-i \"" + TempImagePath + "\" -o \"" + TempBuildPath + "\" --width=128 --height=128 --tga-bpp=32 --tga-compression=none");
                File.Delete(@"Convert\" + filename); + filename2 + ".tga"*/
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier converti !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File converted !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルが変換されました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei konvertiert !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo convertido !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File convertito !", "Perma");
                }
            }
        }

        private void button122_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files(*.tga) | *.tga";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                string filename = fileDialog.SafeFileName;
                string filename2 = System.IO.Path.GetFileNameWithoutExtension(filepath);
                try
                {
                    File.Delete(@"Convert\" + filename2 + ".png");
                }
                catch
                { }
                string TempImagePath = filepath;
                string TempBuildPath = Path.GetFullPath(@"Convert\");
                Process start = new Process();
                start.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                start.StartInfo.FileName = @"TOOLDIR\IMG\tga2pngcmd.exe";
                start.StartInfo.Arguments = "-i \"" + TempImagePath + "\" -o \"" + TempBuildPath;
                start.Start();
                start.WaitForExit();
                //Process.Start(@"TOOLDIR\IMG\tga2pngcmd.exe", "-i \"" + TempImagePath + "\" -o \"" + TempBuildPath);
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier converti !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File converted !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルが変換されました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei konvertiert !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo convertido !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File convertito !", "Perma");
                }
            }
        }

        private void button124_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Wii U manual files (*.bfma)|*.bfma";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() == DialogResult.Cancel)
            {
                goto exsub;
            }
            if (!SARC.extract(fileDialog.FileName, fileDialog.FileName + "_extracted"))
            {
                MessageBox.Show("Error !", "Perma");//Error
            }
            else
            {
                Process.Start(fileDialog.FileName + "_extracted");
            }
        exsub:
            fileDialog.Dispose();
        }

        private void button125_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog fbox = new FolderBrowserDialog();
            //SaveFileDialog sbox = new SaveFileDialog();
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            SaveFileDialog fileDialog = new SaveFileDialog();
            //fbox.Description = uwiz_langtext[157]; // "Select a folder to pack into a SARC archive."
            folderDialog.Description = "Select a folder to pack into a manual.bfma";
            folderDialog.SelectedPath = Environment.CurrentDirectory;
            if (folderDialog.ShowDialog() == DialogResult.Cancel)
            {
                goto exsub;
            }
            fileDialog.Filter = "Wii U manual files (*.bfma)|*.bfma"; // "SARC Archives|*.sarc|All Files|*.*"
            fileDialog.InitialDirectory = Environment.CurrentDirectory;
            fileDialog.FileName = System.IO.Path.GetFileName(folderDialog.SelectedPath);
            if (fileDialog.ShowDialog() == DialogResult.Cancel)
            {
                goto exsub;
            }
            if (!SARC.pack(folderDialog.SelectedPath, fileDialog.FileName))
            {
                MessageBox.Show("Error !", "Perma"); // "Error packing SARC archive!"
            }
        exsub:
            fileDialog.Dispose();
            folderDialog.Dispose();
        }
        #endregion

        #region Make lobby
        private void button136_Click(object sender, EventArgs e)
        {
            string lobby = "Perma";
            string GameInitialise = numericUpDown2.Value.ToString();
            string LobbyInterval = numericUpDown1.Value.ToString();
            string LobbyTimer = numericUpDown3.Value.ToString();
            lobby = string.Concat(new string[]
            {
                "<GameMode xmlns=\"Schema.xsd\" version=\"7.0\" name=\"Lobby\" id=\"0\">",
                Environment.NewLine,
                Environment.NewLine,
                "  <!--This Games Rules was make by Perma-->",
                Environment.NewLine,
                Environment.NewLine,
                "  <PlayerGameType>",
                comboBox8.Text,
                "</PlayerGameType>",
                Environment.NewLine,
                Environment.NewLine,
                "  <TeamBasedSpawn>",
            });
            if (checkBox2.Checked)
            {
                lobby = lobby + "true";
            }
            else
            {
                lobby = lobby + "false";
            }
            lobby = string.Concat(new string[]
            {
                lobby,
                "</TeamBasedSpawn>",
                Environment.NewLine,
                "  <LockedInventory>",
            });
            if (checkBox1.Checked)
            {
                lobby = lobby + "true";
            }
            else
            {
                lobby = lobby + "false";
            }
            lobby = string.Concat(new string[]
            {
                lobby,
                "</LockedInventory>",
                Environment.NewLine,
                "  <ShowNametags>",
            });
            if (checkBox6.Checked)
            {
                lobby = lobby + "true";
            }
            else
            {
                lobby = lobby + "false";
            }
            lobby = string.Concat(new string[]
            {
                lobby,
                "</ShowNametags>",
                Environment.NewLine,
                "  <CanTntDestroyBlocks>",
            });
            if (checkBox5.Checked)
            {
                lobby = lobby + "true";
            }
            else
            {
                lobby = lobby + "false";
            }
            lobby = string.Concat(new string[]
            {
                lobby,
                "</CanTntDestroyBlocks>",
                Environment.NewLine,
                Environment.NewLine,
                "  <PlayerAbilities>",
                Environment.NewLine,
                "    <Instabuild>",
            });
            if (checkBox3.Checked)
            {
                lobby = lobby + "true";
            }
            else
            {
                lobby = lobby + "false";
            }
            lobby = string.Concat(new string[]
            {
                lobby,
                "</Instabuild>",
                Environment.NewLine,
                "    <Invulnerable>",
            });
            if (checkBox3.Checked)
            {
                lobby = lobby + "true";
            }
            else
            {
                lobby = lobby + "false";
            }
            lobby = string.Concat(new string[]
            {
                lobby,
                "</Invulnerable>",
                Environment.NewLine,
                "  </PlayerAbilities>",
                Environment.NewLine,
                Environment.NewLine,
                "  <Timers>",
                Environment.NewLine,
                "    <!-- 4J-JEV: Yay Timers! Measured in seconds. -->",
                Environment.NewLine,
                Environment.NewLine,
                "    <!-- Time spent in lobby before selecting gamemode. -->",
                Environment.NewLine,
                "    <GameInitialise duration=\"",
                GameInitialise,
                "\" announceEvery=\"1\"/>",
                Environment.NewLine,
                Environment.NewLine,
                "    <!-- Time spent in lobby between rounds. -->",
                Environment.NewLine,
                "    <LobbyInterval duration=\"",
                LobbyInterval,
                "\" announceEvery=\"1\"/>",
                Environment.NewLine,
                "  </Timers>",
                Environment.NewLine,
                Environment.NewLine,
                "  <Sounds>",
                Environment.NewLine,
                "    <LobbyTimer forLast=\"",
                LobbyTimer,
                "\"/>",
                Environment.NewLine,
                "  </Sounds>",
                Environment.NewLine,
                Environment.NewLine,
            });
            if (comboBox9.Text == "BlackList")
            {
                lobby = lobby + "  <DestroyPermissions mode=\"BlackList\"/>" + Environment.NewLine;
            }
            else
            {
                lobby = lobby + "  <DestroyPermissions mode=\"WhiteList\"/>" + Environment.NewLine;
            }
            if (comboBox10.Text == "BlackList")
            {
                lobby = lobby + "  <PlacePermissions mode=\"BlackList\"/>" + Environment.NewLine;
            }
            else
            {
                lobby = lobby + "  <PlacePermissions mode=\"WhiteList\"/>" + Environment.NewLine;
            }
            if (comboBox11.Text == "BlackList")
            {
                lobby = lobby + "  <UsePermissions mode=\"BlackList\"/>" + Environment.NewLine;
            }
            else
            {
                lobby = string.Concat(new string[]
                {
                    lobby,
                    "  <UsePermissions mode=\"WhiteList\">",
                    Environment.NewLine,
                    "    <!-- Bow -->",
                    Environment.NewLine,
                    "    <Exception id=\"261\"/>",
                    Environment.NewLine,
                    "    <!-- Arrow -->",
                    Environment.NewLine,
                    "    <Exception id=\"262\"/>",
                    Environment.NewLine,
                    "    <!-- Fishing rod -->",
                    Environment.NewLine,
                    "    <Exception id=\"346\"/>",
                    Environment.NewLine,
                    "    <!-- Snowballs -->",
                    Environment.NewLine,
                    "    <Exception id=\"332\"/>",
                    Environment.NewLine,
                    "    <!-- Elytra -->",
                    Environment.NewLine,
                    "    <Exception id=\"443\"/>",
                    Environment.NewLine,
                    "    <!-- Ward Disc -->",
                    Environment.NewLine,
                    "    <Exception id=\"2265\"/>",
                    Environment.NewLine,
                    "    <!-- 13 Disc -->",
                    Environment.NewLine,
                    "    <Exception id=\"2256\"/>",
                    Environment.NewLine,
                    "    <!-- Strad Disc -->",
                    Environment.NewLine,
                    "    <Exception id=\"2264\"/>",
                    Environment.NewLine,
                    "    <!-- 11 Disc -->",
                    Environment.NewLine,
                    "    <Exception id=\"2266\"/>",
                    Environment.NewLine,
                    "    <!-- here are we now Disc -->",
                    Environment.NewLine,
                    "    <Exception id=\"2267\"/>",
                    Environment.NewLine,
                    "    <!-- Cat Disc -->",
                    Environment.NewLine,
                    "    <Exception id=\"2257\"/>",
                    Environment.NewLine,
                    "    <!-- Blocks Disc -->",
                    Environment.NewLine,
                    "    <Exception id=\"2258\"/>",
                    Environment.NewLine,
                    "    <!-- Chirp Disc -->",
                    Environment.NewLine,
                    "    <Exception id=\"2259\"/>",
                    Environment.NewLine,
                    "    <!-- Far Disc -->",
                    Environment.NewLine,
                    "    <Exception id=\"2260\"/>",
                    Environment.NewLine,
                    "    <!-- Stal Disc -->",
                    Environment.NewLine,
                    "    <Exception id=\"2263\"/>",
                    Environment.NewLine,
                    "    <!-- Mall Disc -->",
                    Environment.NewLine,
                    "    <Exception id=\"2261\"/>",
                    Environment.NewLine,
                    "    <!-- Mellohi Disc -->",
                    Environment.NewLine,
                    "    <Exception id=\"2262\"/>",
                    Environment.NewLine,
                    "  </UsePermissions>",
                    Environment.NewLine,
                });
            }
            if (comboBox12.Text == "BlackList")
            {
                lobby = lobby + "  <BlockUsePermissions mode=\"BlackList\"/>" + Environment.NewLine;
            }
            else
            {
                lobby = string.Concat(new string[]
                {
                    lobby,
                    "  <BlockUsePermissions mode=\"WhiteList\">",
                    Environment.NewLine,
                    "    <!-- Oak Door -->",
                    Environment.NewLine,
                    "    <Exception id=\"64\"/>",
                    Environment.NewLine,
                    "    <!-- Iron Door -->",
                    Environment.NewLine,
                    "    <Exception id=\"71\"/>",
                    Environment.NewLine,
                    "    <!-- Spruce Door -->",
                    Environment.NewLine,
                    "    <Exception id =\"193\"/>",
                    Environment.NewLine,
                    "    <!-- Birch Door -->",
                    Environment.NewLine,
                    "    <Exception id=\"194\"/>",
                    Environment.NewLine,
                    "    <!-- Jungle Door -->",
                    Environment.NewLine,
                    "    <Exception id=\"195\"/>",
                    Environment.NewLine,
                    "    <!-- Acacia Door -->",
                    Environment.NewLine,
                    "    <Exception id=\"196\"/>",
                    Environment.NewLine,
                    "    <!-- Dark Oak Door -->",
                    Environment.NewLine,
                    "    <Exception id=\"197\"/>",
                    Environment.NewLine,
                    Environment.NewLine,
                    "    <!-- Iron TrapDoor -->",
                    Environment.NewLine,
                    "    <Exception id=\"167\"/>",
                    Environment.NewLine,
                    "    <!-- Wooden TrapDoor -->",
                    Environment.NewLine,
                    "    <Exception id=\"96\"/>",
                    Environment.NewLine,
                    Environment.NewLine,
                    "    <!-- Stone Button -->",
                    Environment.NewLine,
                    "    <Exception id=\"77\"/>",
                    Environment.NewLine,
                    "    <!-- Woodean Button -->",
                    Environment.NewLine,
                    "    <Exception id =\"143\"/>",
                    Environment.NewLine,
                    Environment.NewLine,
                    "    <!-- Lever -->",
                    Environment.NewLine,
                    "    <Exception id=\"69\"/>",
                    Environment.NewLine,
                    Environment.NewLine,
                    "    <!-- Chest -->",
                    Environment.NewLine,
                    "    <Exception id =\"54\"/>",
                    Environment.NewLine,
                    "    <!-- Ender chest -->",
                    Environment.NewLine,
                    "    <Exception id=\"130\"/>",
                    Environment.NewLine,
                    "    <!-- Trapped Chest -->",
                    Environment.NewLine,
                    "    <Exception id=\"146\"/>",
                    Environment.NewLine,
                    "    <!-- Note Block -->",
                    Environment.NewLine,
                    "     <Exception id=\"25\"/>",
                    Environment.NewLine,
                    "    <!-- Jukebox -->",
                    Environment.NewLine,
                    "     <Exception id=\"84\"/>",
                    Environment.NewLine,
                    Environment.NewLine,
                    "    <!-- Oak Fence Gate -->",
                    Environment.NewLine,
                    "     <Exception id=\"107\"/>",
                    Environment.NewLine,
                    "    <!-- Spruce Fence Gate -->",
                    Environment.NewLine,
                    "     <Exception id=\"183\"/>",
                    Environment.NewLine,
                    "    <!-- Birch Fence Gate -->",
                    Environment.NewLine,
                    "     <Exception id=\"184\"/>",
                    Environment.NewLine,
                    "    <!-- Jungle Fence Gate -->",
                    Environment.NewLine,
                    "     <Exception id=\"185\"/>",
                    Environment.NewLine,
                    "    <!-- Dark Fence Gate -->",
                    Environment.NewLine,
                    "     <Exception id=\"186\"/>",
                    Environment.NewLine,
                    "    <!-- Acacia Fence Gate -->",
                    Environment.NewLine,
                    "     <Exception id=\"187\"/>",
                    Environment.NewLine,
                    "  </BlockUsePermissions>",
                    Environment.NewLine,
                });
            }
            lobby = string.Concat(new string[]
            {
                lobby,
                Environment.NewLine,
                "</GameMode>",
            });
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Lobby gamerules files (*.xml)|*.xml";
            fileDialog.InitialDirectory = Environment.CurrentDirectory;
            fileDialog.FileName = System.IO.Path.GetFileName("lobby.xml");
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(fileDialog.FileName, lobby);
            }
            fileDialog.Dispose();
        }

        private void button137_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Lobby gamerules files (*.xml)|*.xml";
            fileDialog.InitialDirectory = Environment.CurrentDirectory;
            fileDialog.FileName = System.IO.Path.GetFileName("lobby.xml");
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(fileDialog.FileName, testText.Text);
            }
            fileDialog.Dispose();
        }
        #endregion

        #region Minigames
        private void button131_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\Common\res\TitleUpdate\GameRules\";
            file.Text = "lobby.xml";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button135_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Xml files (*.xml)|*.xml";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox42.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\lobby.xml");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\lobby.xml");
            }
        }

        private void button134_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\Common\res\TitleUpdate\GameRules\";
            file.Text = "MG01.xml";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button130_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Xml files (*.xml)|*.xml";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox42.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\MG01.xml");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\MG01.xml");
            }
        }

        private void button133_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\Common\res\TitleUpdate\GameRules\";
            file.Text = "MG02.xml";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button129_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Xml files (*.xml)|*.xml";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox42.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\MG02.xml");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\MG02a.xml");
            }
        }

        private void button132_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                storage.Text = "storage_mlc";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                storage.Text = "storage_usb";
            }
            if (comboBox2.SelectedIndex == 0)
            {
                region.Text = "101d7500";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                region.Text = "101d9d00";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                region.Text = "101dbe00";
            }
            app.Text = "0005000e";
            chemin.Text = @"content\Common\res\TitleUpdate\GameRules\";
            file.Text = "MG03.xml";
            try
            {
                downloadFile();
                if (fr.Checked)
                {
                    MessageBox.Show("Fichier téléchargé !", "Perma");
                }
                if (en.Checked)
                {
                    MessageBox.Show("File downloaded !", "Perma");
                }
                if (ja.Checked)
                {
                    MessageBox.Show("ファイルをダウンロードしました ！", "Perma");
                }
                if (de.Checked)
                {
                    MessageBox.Show("Datei heruntergeladen !", "Perma");
                }
                if (es.Checked)
                {
                    MessageBox.Show("Archivo descargado !", "Perma");
                }
                if (it.Checked)
                {
                    MessageBox.Show("File scaricato !", "Perma");
                }
            }
            catch
            { }
        }

        private void button128_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Xml files (*.xml)|*.xml";
            fileDialog.Title = Resources.DialogOpen;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                textBox42.Text = fileDialog.FileName;
                try
                {
                    File.Delete(@"Upload\MG03.xml");
                }
                catch
                { }
                File.Copy(fileDialog.FileName, @"Upload\MG03.xml");
            }
        }

        #region Change
        private void button126_Click(object sender, EventArgs e)
        {
            if (fr.Checked)
            {
                if (MessageBox.Show("Êtes-vous sûr de vouloir modifier les game rules ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label71.Text = "Téléchargement : Installation en cours (0%)";
                    string downloadPourcentage = "Téléchargement : Installation en cours";
                    progressBar5.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    chemin.Text = @"content\Common\res\TitleUpdate\GameRules\";
                    //Upload des fichiers
                    try
                    {
                        uploadFile(@"Upload\lobby.xml");
                        File.Delete(@"Upload\lobby.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG01.xml");
                        File.Delete(@"Upload\MG01.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG02.xml");
                        File.Delete(@"Upload\MG02.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG03.xml");
                        File.Delete(@"Upload\MG03.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label71.Text = "Téléchargement : Installation réussie ! (100%)";
                    progressBar5.Value = progressBar5.Maximum;
                }
                else
                { }
            }
            if (en.Checked)
            {
                if (MessageBox.Show("Are you sure you want to change the game rules ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label71.Text = "Download : Installation in progress (0%)";
                    string downloadPourcentage = "Download: Installation in progress";
                    progressBar5.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    chemin.Text = @"content\Common\res\TitleUpdate\GameRules\";
                    //Upload des fichiers
                    try
                    {
                        uploadFile(@"Upload\lobby.xml");
                        File.Delete(@"Upload\lobby.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG01.xml");
                        File.Delete(@"Upload\MG01.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG02.xml");
                        File.Delete(@"Upload\MG02.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG03.xml");
                        File.Delete(@"Upload\MG03.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label71.Text = "Download : Installation successful ! (100%)";
                    progressBar5.Value = progressBar5.Maximum;
                }
                else
                { }
            }
            if (ja.Checked)
            {
                if (MessageBox.Show("ゲームのルールを変更してもよろしいですか ？", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label71.Text = "ダウンロード：インストール中 (0%)";
                    string downloadPourcentage = "ダウンロード：インストール中";
                    progressBar5.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    chemin.Text = @"content\Common\res\TitleUpdate\GameRules\";
                    //Upload des fichiers
                    try
                    {
                        uploadFile(@"Upload\lobby.xml");
                        File.Delete(@"Upload\lobby.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG01.xml");
                        File.Delete(@"Upload\MG01.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG02.xml");
                        File.Delete(@"Upload\MG02.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG03.xml");
                        File.Delete(@"Upload\MG03.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label71.Text = "Tダウンロード：インストールに成功しました！ (100%)";
                    progressBar5.Value = progressBar5.Maximum;
                }
                else
                { }
            }
            if (de.Checked)
            {
                if (MessageBox.Show("Möchten Sie die Spielregeln wirklich ändern ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label71.Text = "Download : Installation läuft(0%)";
                    string downloadPourcentage = "Download : Installation läuft";
                    progressBar5.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    chemin.Text = @"content\Common\res\TitleUpdate\GameRules\";
                    //Upload des fichiers
                    try
                    {
                        uploadFile(@"Upload\lobby.xml");
                        File.Delete(@"Upload\lobby.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG01.xml");
                        File.Delete(@"Upload\MG01.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG02.xml");
                        File.Delete(@"Upload\MG02.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG03.xml");
                        File.Delete(@"Upload\MG03.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label71.Text = "Download : Installation erfolgreich! (100%)";
                    progressBar5.Value = progressBar5.Maximum;
                }
                else
                { }
            }
            if (es.Checked)
            {
                if (MessageBox.Show("¿Estás seguro de que quieres cambiar las reglas del juego?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label71.Text = "Descarga : instalación en curso(0%)";
                    string downloadPourcentage = "Descarga : instalación en curso";
                    progressBar5.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    chemin.Text = @"content\Common\res\TitleUpdate\GameRules\";
                    //Upload des fichiers
                    try
                    {
                        uploadFile(@"Upload\lobby.xml");
                        File.Delete(@"Upload\lobby.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG01.xml");
                        File.Delete(@"Upload\MG01.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG02.xml");
                        File.Delete(@"Upload\MG02.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG03.xml");
                        File.Delete(@"Upload\MG03.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label71.Text = "Descarga : ¡Instalación exitosa! (100%)";
                    progressBar5.Value = progressBar5.Maximum;
                }
                else
                { }
            }
            if (it.Checked)
            {
                if (MessageBox.Show("Sei sicuro di voler cambiare le regole del gioco ?", "Perma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Préparation :
                    label71.Text = "Download : installazione in corso (0%)";
                    string downloadPourcentage = "Download : installazione in corso";
                    progressBar5.Value = 0;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        storage.Text = "storage_mlc";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        storage.Text = "storage_usb";
                    }
                    if (comboBox2.SelectedIndex == 0)
                    {
                        region.Text = "101d7500";
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        region.Text = "101d9d00";
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        region.Text = "101dbe00";
                    }
                    app.Text = "0005000e";
                    chemin.Text = @"content\Common\res\TitleUpdate\GameRules\";
                    //Upload des fichiers
                    try
                    {
                        uploadFile(@"Upload\lobby.xml");
                        File.Delete(@"Upload\lobby.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG01.xml");
                        File.Delete(@"Upload\MG01.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG02.xml");
                        File.Delete(@"Upload\MG02.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    try
                    {
                        uploadFile(@"Upload\MG03.xml");
                        File.Delete(@"Upload\MG03.xml");
                        progressBar5.Value = progressBar5.Value + 1;
                        int pourcentage = progressBar5.Value * 100 / progressBar5.Maximum;
                        label71.Text = downloadPourcentage + " (" + pourcentage + "%)";
                    }
                    catch
                    { }
                    //fin du téléchargement
                    label71.Text = "Download : installazione riuscita ! (100%)";
                    progressBar5.Value = progressBar5.Maximum;
                }
                else
                {

                }
            }
        }
        #endregion
        #endregion
    }
}