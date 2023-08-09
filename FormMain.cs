using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Linq;
using ImageMagick;
using System.Net.NetworkInformation;
using System.Globalization;

namespace nf
{
    
    public partial class FormMain : Form
    {
        #region свойства

        // json файл  входных параметров
        public string fileIni = @"d:\nft\ini.json";
        public StrictIni iniJson = new StrictIni();

        public string fileInParam = @"d:\nft\InParam.json";
        public string fileImgScr;
        public string colPrefix;

        public StrictParam inParam = new StrictParam();               // для хранения входных параметров

        // json файлы коллекции и nft
        public StrictJsonColl CollectionJson = new StrictJsonColl();
        public string fileCollectionJson;
        public string fileCollectionCsv;
        public string filePathNftJson;
        public string filePathNftImg;
        public string fileNftJson;
        public string[] inImgSet = new string[] { "", "", "", "", "", "", "", "", "", "", "" };   //набор имен входных файлов изображения

        // переменные для изображений
        public string InputImage = @"d:\nft\cat\OriginalImage.jpg";
        public string SaveImage = @"d:\nft\cat\NormalizeImage.jpg";

        // набор текущих атрибутов
        public StrictJsonNft nftJson = new StrictJsonNft();          // для создания и сохранения meta файлов Nft
        public int[] curAtt = new int[] { -1,0,0,0,0,0,0,0,0,0 };

        Timer refrTimer = new Timer();
        #endregion

        public FormMain()
        {
            InitializeComponent();

            // считать и распарсить файл ini.json
            string inIni = File.ReadAllText(fileIni);
            iniJson = JsonConvert.DeserializeObject<StrictIni>(inIni);

            checkCreateImage.Checked = iniJson.needCreateImage;
            numericUpDownSize.Value = iniJson.sizeImage;
            checkMetaCollection.Checked = iniJson.needCreateMetaCol;
            checkCreateMeta.Checked = iniJson.needCreateMetaNft;
            checkCreateScv.Checked = iniJson.needCreateScv;
            numericUpDownNOut.Value = iniJson.cOut;
            checkInsDeploy.Checked = iniJson.needCreateDeploy;

            // считать и распарсить файл входных данных
            string inParamTxt = File.ReadAllText(fileInParam);
            inParam = JsonConvert.DeserializeObject<StrictParam>(inParamTxt);

            // изменить некоторые данные на пользователькие
            inParam.cOut = (int)numericUpDownNOut.Value;

        }

        private void CreateMetaFileCollection()   // создать файл meta.json для коллекции - статичный, делается один раз
        {
            // создать и сохранить CollectionJson
            CollectionJson.name = inParam.CLname;
            CollectionJson.description = inParam.CLdescription;
            CollectionJson.image = String.Format(inParam.CLimage, inParam.nPathCol);
            CollectionJson.cover_image = String.Format(inParam.CLcover_image, inParam.nPathCol);

            Array.Resize(ref CollectionJson.social_links, inParam.CLsocial_links.Length);
            for (int i = 0; i < inParam.CLsocial_links.Length; i++)
                CollectionJson.social_links[i] = inParam.CLsocial_links[i];


            // сохранить CollectionJson
            string toSaveCollectionJson = JsonConvert.SerializeObject(CollectionJson, Formatting.Indented);
            File.WriteAllText(fileCollectionJson, toSaveCollectionJson);
        }
        private void CreateMetaFileNft(int NumftN)   // создать файл metaNftN.json для nft с номером NumftN
        {
            // создать и сохранить первые 4 поля nftJson
            nftJson.name = String.Format(inParam.NFTname, NumftN);
            nftJson.description = inParam.NFTdescription;
            nftJson.content_url = inParam.NFTcontent_url;
            nftJson.image = String.Format(inParam.NFTimage, colPrefix, inParam.nPathImage, inParam.nPathCol, NumftN);

            // цикл по возможным атрибутов, добавление текущих в заготовку файла
            for (int j = 0; j < inParam.ncAttr.Length; j++)
            {
                StrictOneattribut attribut = new StrictOneattribut();
                // набор текущих атрибутов
                attribut.trait_type = inParam.ncAttr[j].fileNameAtr;
                attribut.value = inParam.ncAttr[j].tr[curAtt[j]];

                nftJson.attributes[j] = attribut;
            }

            // сохранить nftJson
            string outftJson = JsonConvert.SerializeObject(nftJson, Formatting.Indented);
            string NFoutftJson = String.Format(fileNftJson, NumftN);

            File.WriteAllText(NFoutftJson, outftJson);
        }
        private void CreateFileCsv()       // создать файл с адресами владельцев Nft
        {
            // создать и сохранить файл csv
            string outCsvJson = "";
            int CntOwner = 0;
            for (int i = 0; i < inParam.address.Length; i++)
            {
                for (int j = 0; j < inParam.address[i].countNft; j++)
                {
                    outCsvJson = outCsvJson + CntOwner + "," + inParam.address[i].owner + "\r\n";
                    CntOwner++;
                    if (CntOwner >= inParam.cOut) break;    //  выходим из основного цикла
                }
                if (CntOwner >= inParam.cOut) break;    //  выходим из основного цикла
            }
            outCsvJson = outCsvJson + CntOwner + "\r\n";
            // сохранить csv
            File.WriteAllText(fileCollectionCsv, outCsvJson);

            //

        }
        private void CreateInsDeploy()       // создать файл инструкцию по развертыванию коллекции и Nft 
        {
            // создать и сохранить файл csv
            string outCsvJson = "";
            int CntOwner = 0;
            for (int i = 0; i < inParam.address.Length; i++)
            {
                for (int j = 0; j < inParam.address[i].countNft; j++)
                {
                    outCsvJson = outCsvJson + CntOwner + "," + inParam.address[i].owner + "\r\n";
                    CntOwner++;
                    if (CntOwner >= inParam.cOut) break;    //  выходим из основного цикла
                }
                if (CntOwner >= inParam.cOut) break;    //  выходим из основного цикла
            }
            outCsvJson = outCsvJson + CntOwner + "\r\n";
            // сохранить csv
            File.WriteAllText(fileCollectionCsv, outCsvJson);

            //

        }
        private void CreateImageNft(int numNft)   // создать выходное изображение для nft с номером numNft с заданными атрибутами
        {
            //В переменной SaveImagePath указать путь куда сохраняем обработанное изображение
            string SaveImagePath = filePathNftImg + inParam.nPathCol + "_" + numNft + ".png";   
            // создать набор имен входных файлов изображения
            for (int i = 0; i < inParam.ncAttr.Length; i++)
                inImgSet[i] = fileImgScr + inParam.ncAttr[i].fileNameAtr + "_" + inParam.ncAttr[i].tr[curAtt[i]] + ".png";

            // создать и сохранить изображение
            MagickGeometry size = new MagickGeometry(800); // желаемый размер изображения

            MagickImage image = new MagickImage(inImgSet[0]);
            image.Resize(size);

            for (int i = 1; i < inParam.ncAttr.Length; i++)
            {
                MagickImage image1 = new MagickImage(inImgSet[i]);
                image1.Resize(size);
                image.Composite(image1, CompositeOperator.Over);               // наложение
            }

            //сохранить результат
            image.Write(SaveImagePath);
        }
        private void Create_Click(object sender, EventArgs e)
        {
            //  Прописать имена файлов и каталогов
            inParam.nameWorkPath = @"d:\" + inParam.nameWorkPath;
            fileImgScr = $"{inParam.nameWorkPath}\\{inParam.nPathCol}ImgScr\\";                      //каталог с исходными файлами
            fileCollectionJson = $"{inParam.nameWorkPath}\\{inParam.nPathCol}\\Collection.json";     //полное имя файла json коллециии
            filePathNftJson = $"{inParam.nameWorkPath}\\{inParam.nPathCol}\\{inParam.nPathMeta}\\";  //каталог для meta файлов Nft
            filePathNftImg = $"{inParam.nameWorkPath}\\{inParam.nPathCol}\\{inParam.nPathImage}\\";  //каталог для файлов изображений Nft
            fileNftJson = $"{filePathNftJson}{{0}}.json";                                            //заготовка для имен meta файлов Nft
            fileCollectionCsv = $"{inParam.nameWorkPath}\\{inParam.nPathCol}\\{inParam.nPathCol}.csv";     //имя файла csv
            colPrefix = String.Format(inParam.Prefix, inParam.nPathCol);                             // создать строку префикса адреса хранения meta файлов Nft

            // создать массив атрибутов                   
            Array.Resize(ref nftJson.attributes, inParam.ncAttr.Length);

            //создать каталоги
            Directory.CreateDirectory(filePathNftJson);
            Directory.CreateDirectory(filePathNftImg);

            if (checkMetaCollection.Checked)
                CreateMetaFileCollection();                // создать файл meta.json для коллекции - статичный, делается один раз

            // основной цикл создания картинок nft, файлов meta для каждой nft
            // выполняется cOut либо по исчерпании всех возможных комбинаций атрибутов
            bool attrEnd = false;
            for (int i = 0; i < inParam.cOut; i++)
            {
                // создать очередную комбинацию атрибутов
                for (int j = 0; j < inParam.ncAttr.Length; j++)
                {
                    curAtt[j]++;
                    if (curAtt[j] < inParam.ncAttr[j].tr.Length)
                    {
                        break;
                    } else
                    {
                        curAtt[j] = 0;
                        if (j == inParam.ncAttr.Length - 1) attrEnd = true;
                    };

                }
                if (attrEnd) break;                       //  все атрибуты перебраны, выходим из основного цикла

                if (checkCreateImage.Checked)
                    CreateImageNft(i);                     // создать файл изображения .json для nft с номером i

                if (checkCreateMeta.Checked)
                    CreateMetaFileNft(i);                  // создать файл metaNftN.json для nft с номером i

                //вывод на экран для индикации
                OutArea.Text = "данные для nft # " + i + " сформированы и сохранены\r\n";
            }

            if (checkCreateScv.Checked)                    // создать файл с адресами владельцев Nft
                CreateFileCsv();

            if (checkInsDeploy.Checked)                    // создать файл инструкцию по развертыванию коллекции и Nft 
                CreateInsDeploy();

        }
        //**************************************************
        private void checkCreateImage_CheckedChanged(object sender, EventArgs e)
        {
            iniJson.needCreateImage = checkCreateImage.Checked;
        }
        private void numericUpDownSize_ValueChanged(object sender, EventArgs e)
        {
            iniJson.sizeImage = (int)numericUpDownSize.Value;
        }

        private void checkMetaCollection_CheckedChanged(object sender, EventArgs e)
        {
            iniJson.needCreateMetaCol = checkMetaCollection.Checked;
        }

        private void checkCreateMeta_CheckedChanged(object sender, EventArgs e)
        {
            iniJson.needCreateMetaNft = checkCreateMeta.Checked;
        }

        private void checkCreateScv_CheckedChanged(object sender, EventArgs e)
        {
            iniJson.needCreateScv = checkCreateScv.Checked;
        }

        private void numericUpDownNOut_ValueChanged(object sender, EventArgs e)
        {
            iniJson.cOut = (int)numericUpDownNOut.Value;
        }

        private void checkInsDeploy_CheckedChanged(object sender, EventArgs e)
        {
            iniJson.needCreateDeploy = checkInsDeploy.Checked;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
               // сохранить файл ini.json
            string outIniJson = JsonConvert.SerializeObject(iniJson, Formatting.Indented);
            File.WriteAllText(fileIni, outIniJson);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    #region классы и структуры

    // ДЛЯ ХРАНЕНИЯ ИНФЫ ОБ 1 НОМЕРЕ
    public enum EnumstatNftTel
    {
        OnSale,
        Sold,
        OnAuction
    }
    public class StrictJsonColl
    {
        public string name;
        public string description;
        public string image;
        public string cover_image;
        public string[] social_links = new string[0];
    }
    public class StrictOneattribut
    {
        public string trait_type;
        public string value;
    }
    public class StrictJsonNft
    {
        public string name;
        public string description;
        public string image;
        public string content_url;

        public StrictOneattribut[] attributes = new StrictOneattribut[0];
    }
    public class StrictOneTrait
    {
        public string fileNameAtr;
        public string[] tr = new string[0];
    }
    public class StrictOneOwner
    {
        public string owner;
        public int countNft;
    }
    public class StrictParam
    {        
        public string nameWorkPath;
        // Название файлов и путей: <название/папка коллекции>, <папка с мета файлами>, <папка с файлами изображений>,
        // <Имя текущего выходного файла>, <Максимальное кол-во создаваемых файлов>
        public string nPathCol;
        public string nPathMeta;
        public string nPathImage;
        public string Prefix;
        public int cOut;
        // Данные для файла JSON коллекции
        public string CLname;
        public string CLdescription;
        public string CLimage;
        public string CLcover_image;
        public string[] CLsocial_links = new string[0];

        // Данные для файла JSON NFT
        // Описание первых 4 атрибутов <number>, <description>, <addres картинки в сети>, <content_url>
        public string NFTname;
        public string NFTdescription;
        public string NFTimage;
        public string NFTcontent_url;

        // Описание атрибутов: <общее кол-во атрибутов>, <название основной части файла атрибута n>, <кол-во элементов атрибута n>,
        // <название атрибута 1>, <название атрибута n>
        public StrictOneTrait[] ncAttr = new StrictOneTrait[0];

        // Данные адресов собственников
        public StrictOneOwner[] address = new StrictOneOwner[0];
    }

    public class StrictIni
    {
        public bool needCreateMetaCol;
        public bool needCreateMetaNft;
        public bool needCreateImage;
        public bool needCreateScv;
        public bool needCreateInstr;
        public bool needCreateDeploy;
        public int cOut;
        public int sizeImage;
    }

    #endregion


}
