using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;

namespace valo
{
    public partial class _Default : Page
    {
        public static List<Skin> allSkin = new List<Skin>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add("Classic");
                DropDownList2.Items.Add("Shorty");
                DropDownList2.Items.Add("Frenzy");
                DropDownList2.Items.Add("Ghost");
                DropDownList2.Items.Add("Sherieff");
                DropDownList2.Items.Add("Stinger");
                DropDownList2.Items.Add("Spectre");
                DropDownList2.Items.Add("Bucky");
                DropDownList2.Items.Add("Judge");
                DropDownList2.Items.Add("Bulldog");
                DropDownList2.Items.Add("Guardian");
                DropDownList2.Items.Add("Phantom");
                DropDownList2.Items.Add("Vandal");
                DropDownList2.Items.Add("Marshal");
                DropDownList2.Items.Add("Operator");
                DropDownList2.Items.Add("Ares");
                DropDownList2.Items.Add("Odin");
                DropDownList2.Items.Add("Knife");
                getAllSkin("en-US");
                DropDownList3.Items.Clear();
                foreach (Skin ss in allSkin)
                {
                    if (ss.displayName.Contains(DropDownList2.SelectedValue))
                    {
                        DropDownList3.Items.Add(ss.displayName);
                    }
                }
                Skin s = findSkin(DropDownList3.SelectedValue);
                Image1.ImageUrl = s.displayIcon;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = "w";
            if (DropDownList1.SelectedValue == "English")
            {
                Label1.Text = "Language: ";
                Label2.Text = "Type: ";
                Label3.Text = "Skin: ";
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add("Classic");
                DropDownList2.Items.Add("Shorty");
                DropDownList2.Items.Add("Frenzy");
                DropDownList2.Items.Add("Ghost");
                DropDownList2.Items.Add("Sherieff");
                DropDownList2.Items.Add("Stinger");
                DropDownList2.Items.Add("Spectre");
                DropDownList2.Items.Add("Bucky");
                DropDownList2.Items.Add("Judge");
                DropDownList2.Items.Add("Bulldog");
                DropDownList2.Items.Add("Guardian");
                DropDownList2.Items.Add("Phantom");
                DropDownList2.Items.Add("Vandal");
                DropDownList2.Items.Add("Marshal");
                DropDownList2.Items.Add("Operator");
                DropDownList2.Items.Add("Ares");
                DropDownList2.Items.Add("Odin");
                DropDownList2.Items.Add("Knife");
                Button1.Text = "Add to List";
                Button2.Text = "Generate Image";
                Button3.Text = "Delete Selected skin";
                getAllSkin("en-US");
                DropDownList3.Items.Clear();
                foreach (Skin ss in allSkin)
                {
                    if (ss.displayName.Contains(DropDownList2.SelectedValue))
                    {
                        DropDownList3.Items.Add(ss.displayName);
                    }
                }
                Skin s = findSkin(DropDownList3.SelectedValue);
                Image1.ImageUrl = s.displayIcon;
            }
            else if (DropDownList1.SelectedValue == "中文")
            {
                Label1.Text = "語言: ";
                Label2.Text = "槍種: ";
                Label3.Text = "造型: ";
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add("制式手槍");
                DropDownList2.Items.Add("短管");
                DropDownList2.Items.Add("狂弒");
                DropDownList2.Items.Add("鬼魅");
                DropDownList2.Items.Add("神射");
                DropDownList2.Items.Add("刺針");
                DropDownList2.Items.Add("惡靈");
                DropDownList2.Items.Add("重砲");
                DropDownList2.Items.Add("判官");
                DropDownList2.Items.Add("鬥牛犬");
                DropDownList2.Items.Add("捍衛者");
                DropDownList2.Items.Add("幻象");
                DropDownList2.Items.Add("暴徒");
                DropDownList2.Items.Add("警長");
                DropDownList2.Items.Add("間諜");
                DropDownList2.Items.Add("戰神");
                DropDownList2.Items.Add("奧丁");
                DropDownList2.Items.Add("小刀");
                Button1.Text = "加入列表";
                Button2.Text = "生成圖片";
                Button3.Text = "刪除所選槍皮";
                getAllSkin("zh-TW");
                DropDownList3.Items.Clear();
                foreach (Skin ss in allSkin)
                {
                    if (ss.displayName.Contains(DropDownList2.SelectedValue))
                    {
                        DropDownList3.Items.Add(ss.displayName);
                    }
                }
                Skin s = findSkin(DropDownList3.SelectedValue);
                Image1.ImageUrl = s.displayIcon;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        private static Skin findSkin(string n)
        {
            foreach (Skin s in allSkin)
            {
                if (s.displayName == n)
                {
                    return s;
                }
            }
            return allSkin[0];
        }
        private static void getAllSkin(string l)
        {
            string url = "https://valorant-api.com/v1/weapons/skins?language=" + l;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = 0;
            string responseStr = "";
            // 取得回應資料
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = sr.ReadToEnd();
                }//end using  
            }
            rqdata rqd = JsonConvert.DeserializeObject<rqdata>(responseStr);//反序列化
            allSkin = rqd.data;
            clearskins();

        }
        private static void clearskins()
        {
            bool parse = true;
            while (parse)
            {
                try
                {

                    foreach (Skin s in allSkin)
                    {
                        if (s.displayIcon == null)
                        {
                            allSkin.Remove(s);
                        }
                        else if (s.displayName == null)
                        {
                            allSkin.Remove(s);
                        }
                    }
                    Thread.Sleep(1000);
                }
                catch (InvalidOperationException)
                {
                    break;
                }
                finally
                {
                    parse = false;
                }
            }
        }




        public class rqdata
        {
            public string status;
            public List<Skin> data;
        }
        public class Skin
        {
            public string displayName;
            public string displayIcon;
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Skin s = findSkin(DropDownList3.SelectedValue);
            Image1.ImageUrl = s.displayIcon;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList3.Items.Clear();
            foreach (Skin s in allSkin)
            {
                if (s.displayName.Contains(DropDownList2.SelectedValue))
                {
                    DropDownList3.Items.Add(s.displayName);
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            ListBox1.Items.Add(DropDownList3.SelectedValue);
        }
        private static System.Drawing.Image getImageFromURL(string url)
        {
            try
            {
                System.Drawing.Image img;
                var request = WebRequest.Create(url);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    img = System.Drawing.Image.FromStream(stream);
                }
                return img;
            }
            catch (InvalidDataException)
            {

            }
            finally
            {

            }
            return null;
        }
        private static System.Drawing.Image BlankImage(int x, int y)
        {
            Bitmap bmp = new Bitmap(x, y);

            return (System.Drawing.Image)bmp;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            String fileName = "~/Content/weapon_Skins.png";
            fileName = Server.MapPath(fileName);
            Bitmap bmp = new Bitmap(fileName);
            if (File.Exists(fileName))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    // do stuff here
                }
            }
            System.Drawing.Image bg = (System.Drawing.Image)bmp;
            System.Drawing.Image ClassicBG = BlankImage(320, 140);
            System.Drawing.Image ShortyBG = BlankImage(320, 140);
            System.Drawing.Image FrenzyBG = BlankImage(320, 140);
            System.Drawing.Image GhostBG = BlankImage(320, 140);
            System.Drawing.Image SheriffBG = BlankImage(320, 140);
            System.Drawing.Image StingerBG = BlankImage(320, 140);
            System.Drawing.Image SpectreBG = BlankImage(320, 140);
            System.Drawing.Image BuckyBG = BlankImage(320, 140);
            System.Drawing.Image JudgeBG = BlankImage(320, 140);
            System.Drawing.Image BulldogBG = BlankImage(320, 140);
            System.Drawing.Image GuardianBG = BlankImage(320, 140);
            System.Drawing.Image PhantomBG = BlankImage(320, 140);
            System.Drawing.Image VandalBG = BlankImage(320, 140);
            System.Drawing.Image MarshalBG = BlankImage(320, 140);
            System.Drawing.Image OperatorBG = BlankImage(320, 140);
            System.Drawing.Image AresBG = BlankImage(320, 140);
            System.Drawing.Image OdinBG = BlankImage(320, 140);
            System.Drawing.Image KnifeBG = BlankImage(320, 140);
            List<string> ClassicList = new List<string>();
            int classicOffset = 0;
            int shortyOffset = 0;
            int ghostOffset = 0;
            int frenzyOffset = 0;
            int sheriffOffset = 0;
            int stingerOffset = 0;
            int spectreOffset = 0;
            int buckyOffset = 0;
            int judgeOffset = 0;
            int bulldogOffset = 0;
            int guardianOffset = 0;
            int phantomOffset = 0;
            int vandalOffset = 0;
            int marshalOffset = 0;
            int operatorOffset = 0;
            int aresOffset = 0;
            int odinOffset = 0;
            int knifeOffset = 0;
            System.Drawing.Image img;
            foreach (var a in ListBox1.Items)
            {
                string n = a.ToString();
                if (n.Contains("制式手槍") || n.Contains("Classic"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 3);
                    var gra = Graphics.FromImage(ClassicBG);
                    gra.DrawImage(img, new PointF(0, classicOffset));
                    classicOffset += 30;
                    Bitmap nbg = new Bitmap(ClassicBG.Width, ClassicBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(ClassicBG, new PointF(0, 0));
                    }
                    ClassicBG = (System.Drawing.Image)nbg;

                }
                else if (n.Contains("短管") || n.Contains("Shorty"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 3);
                    var gra = Graphics.FromImage(ShortyBG);
                    gra.DrawImage(img, new PointF(0, shortyOffset));
                    shortyOffset += 30;
                    Bitmap nbg = new Bitmap(ShortyBG.Width, ShortyBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(ShortyBG, new PointF(0, 0));
                    }
                    ShortyBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("狂弒") || n.Contains("Frenzy"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 3);
                    var gra = Graphics.FromImage(FrenzyBG);
                    gra.DrawImage(img, new PointF(0, frenzyOffset));
                    frenzyOffset += 30;
                    Bitmap nbg = new Bitmap(FrenzyBG.Width, FrenzyBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(FrenzyBG, new PointF(0, 0));
                    }
                    FrenzyBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("鬼魅") || n.Contains("Ghost"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 3);
                    var gra = Graphics.FromImage(GhostBG);
                    gra.DrawImage(img, new PointF(0, ghostOffset));
                    ghostOffset += 30;
                    Bitmap nbg = new Bitmap(GhostBG.Width, GhostBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(GhostBG, new PointF(0, 0));
                    }
                    GhostBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("神射") || n.Contains("Sheriff"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 3);
                    var gra = Graphics.FromImage(SheriffBG);
                    gra.DrawImage(img, new PointF(0, sheriffOffset));
                    sheriffOffset += 30;
                    Bitmap nbg = new Bitmap(SheriffBG.Width, SheriffBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(SheriffBG, new PointF(0, 0));
                    }
                    SheriffBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("刺針") || n.Contains("Stinger"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(StingerBG);
                    gra.DrawImage(img, new PointF(0, stingerOffset));
                    stingerOffset += 30;
                    Bitmap nbg = new Bitmap(StingerBG.Width, StingerBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(StingerBG, new PointF(0, 0));
                    }
                    StingerBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("惡靈") || n.Contains("Spectre"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(SpectreBG);
                    gra.DrawImage(img, new PointF(0, spectreOffset));
                    spectreOffset += 30;
                    Bitmap nbg = new Bitmap(SpectreBG.Width, SpectreBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(SpectreBG, new PointF(0, 0));
                    }
                    SpectreBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("重砲") || n.Contains("Bucky"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(BuckyBG);
                    gra.DrawImage(img, new PointF(0, buckyOffset));
                    buckyOffset += 30;
                    Bitmap nbg = new Bitmap(BuckyBG.Width, BuckyBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(BuckyBG, new PointF(0, 0));
                    }
                    BuckyBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("判官") || n.Contains("Judge"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(JudgeBG);
                    gra.DrawImage(img, new PointF(0, judgeOffset));
                    judgeOffset += 30;
                    Bitmap nbg = new Bitmap(JudgeBG.Width, JudgeBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(JudgeBG, new PointF(0, 0));
                    }
                    JudgeBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("鬥牛犬") || n.Contains("Bulldog"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(BulldogBG);
                    gra.DrawImage(img, new PointF(0, bulldogOffset));
                    bulldogOffset += 30;
                    Bitmap nbg = new Bitmap(BulldogBG.Width, BulldogBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(BulldogBG, new PointF(0, 0));
                    }
                    BulldogBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("捍衛者") || n.Contains("Guardian"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(GuardianBG);
                    gra.DrawImage(img, new PointF(0, guardianOffset));
                    guardianOffset += 30;
                    Bitmap nbg = new Bitmap(GuardianBG.Width, GuardianBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(GuardianBG, new PointF(0, 0));
                    }
                    GuardianBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("幻象") || n.Contains("Phantom"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(PhantomBG);
                    gra.DrawImage(img, new PointF(0, phantomOffset));
                    phantomOffset += 30;
                    Bitmap nbg = new Bitmap(PhantomBG.Width, PhantomBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(PhantomBG, new PointF(0, 0));
                    }
                    PhantomBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("暴徒") || n.Contains("Vandal"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(VandalBG);
                    gra.DrawImage(img, new PointF(0, vandalOffset));
                    vandalOffset += 30;
                    Bitmap nbg = new Bitmap(VandalBG.Width, VandalBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(VandalBG, new PointF(0, 0));
                    }
                    VandalBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("警長") || n.Contains("Marshal"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(MarshalBG);
                    gra.DrawImage(img, new PointF(0, marshalOffset));
                    marshalOffset += 30;
                    Bitmap nbg = new Bitmap(MarshalBG.Width, MarshalBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(MarshalBG, new PointF(0, 0));
                    }
                    MarshalBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("間諜") || n.Contains("Operator"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(OperatorBG);
                    gra.DrawImage(img, new PointF(0, operatorOffset));
                    operatorOffset += 30;
                    Bitmap nbg = new Bitmap(OperatorBG.Width, OperatorBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(OperatorBG, new PointF(0, 0));
                    }
                    OperatorBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("戰神") || n.Contains("Ares"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(AresBG);
                    gra.DrawImage(img, new PointF(0, aresOffset));
                    aresOffset += 30;
                    Bitmap nbg = new Bitmap(AresBG.Width, AresBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(AresBG, new PointF(0, 0));
                    }
                    AresBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("奧丁") || n.Contains("Odin"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(OdinBG);
                    gra.DrawImage(img, new PointF(0, odinOffset));
                    odinOffset += 30;
                    Bitmap nbg = new Bitmap(OdinBG.Width, OdinBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(OdinBG, new PointF(0, 0));
                    }
                    OdinBG = (System.Drawing.Image)nbg;
                }
                else if (n.Contains("小刀") || n.Contains("Knife"))
                {
                    img = getImageFromURL(findSkin(n).displayIcon);
                    img = resizeImagePercent(img, 2);
                    var gra = Graphics.FromImage(KnifeBG);
                    gra.DrawImage(img, new PointF(0, knifeOffset));
                    knifeOffset += 30;
                    Bitmap nbg = new Bitmap(KnifeBG.Width, KnifeBG.Height + 30);
                    using (var g = Graphics.FromImage(nbg))
                    {
                        g.DrawImage(KnifeBG, new PointF(0, 0));
                    }
                    KnifeBG = (System.Drawing.Image)nbg;
                }



            }
            var gr = Graphics.FromImage(bg);
            gr.DrawImage(ClassicBG, 20, 90);
            gr.DrawImage(ShortyBG, 20, 210);
            gr.DrawImage(FrenzyBG, 20, 330);
            gr.DrawImage(GhostBG, 20, 440);
            gr.DrawImage(SheriffBG, 20, 550);

            gr.DrawImage(StingerBG, 180, 90);
            gr.DrawImage(SpectreBG, 180, 210);
            gr.DrawImage(BuckyBG, 180, 330);
            gr.DrawImage(JudgeBG, 180, 440);

            gr.DrawImage(BulldogBG, 430, 90);
            gr.DrawImage(GuardianBG, 430, 210);
            gr.DrawImage(PhantomBG, 430, 330);
            gr.DrawImage(VandalBG, 430, 440);

            gr.DrawImage(MarshalBG, 710, 90);
            gr.DrawImage(OperatorBG, 710, 210);
            gr.DrawImage(AresBG, 710, 330);
            gr.DrawImage(OdinBG, 710, 440);
            gr.DrawImage(KnifeBG, 710, 550);
            gr.Dispose();
            Random r = new Random();
            int na = r.Next(10000000, 99999999);
            File.WriteAllBytes(Server.MapPath("Save/Skin" + na.ToString() + ".png"), imageToByteArray(bg));
            Response.WriteFile(Server.MapPath("Save/Skin" + na.ToString() + ".png"));
            Response.ContentType = "application/PNG";
            Response.AddHeader("content-disposition", "attachment;filename=Skin.png");

            Response.End();
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        private static System.Drawing.Image resizeImagePercent(System.Drawing.Image imgToResize, int rate)
        {
            int destWidth = imgToResize.Width / rate;
            int destHeight = imgToResize.Height / rate;
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }
        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Remove(ListBox1.SelectedValue);
        }
    }
}
