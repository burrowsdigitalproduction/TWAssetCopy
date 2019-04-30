using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TWAsset_Copy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private class Item
        {
            public string FamilyName;
            public string FamilyCode;
            public Item(string name, string value)
            {
                FamilyName = name;
                FamilyCode = value;
            }

            public override string ToString()
            {
                return this.FamilyName;
            }

        }
        public MainWindow()
        {
            InitializeComponent();

            //Add combobox data
            cbAssetFamily.Items.Add(new Item("Towel Rail", "R1001R1002"));
            cbAssetFamily.Items.Add(new Item("Wall Tiles", "R1001R1006"));
            cbAssetFamily.Items.Add(new Item("Flooring", "R1001R1012"));
            cbAssetFamily.Items.Add(new Item("Bath Tap", "R1001R1030"));
            cbAssetFamily.Items.Add(new Item("Basin Tap", "R1001R1042"));
            cbAssetFamily.Items.Add(new Item("Tile Trim", "R1001R1045"));
            cbAssetFamily.Items.Add(new Item("Wash Basin/Vanity", "R1001R2000"));
            cbAssetFamily.Items.Add(new Item("Bath", "R1001R2001"));


            cbAssetFamily.SelectedIndex = 0;

        }

        public List<string> TradCodes = new List<string>
        {
            "__",
            "1518",
            "1519",
            "1625",
            "1626",
            "1627",
            "1628",
            "1629",
            "1630",
            "1631",
            "1642",
            "1643",
            "1644",
            "2790",
            "2791",
            "2792",
            "2793",
            "2794",
            "2795",
            "2796",
            "2797"
        };

        public List<string> WallTileCodes = new List<string>
        {
        "1045",
        "1046",
        "1047",
        "1049",
        "1050",
        "1051",
        "1052",
        "1053",
        "1054",
        "1055",
        "1056",
        "1057",
        "1058",
        "1059",
        "1060",
        "1061",
        "1065",
        "1066",
        "1067",
        "1068",
        "1069",
        "1070",
        "1450",
        "1633",
        "1634",
        "1635",
        "1636",
        "1637",
        "1638",
        "1639",
        "1640",
        "1641"
        };

        public List<string> BasinTapCodes = new List<string>
        {
            "1010",
            "1026",
            "1029"
        };

        public List<string> TileTrimCodes = new List<string>
        {
            "1507",
            "1509"
        };

        public List<string> PackageCodes = new List<string>
        {
            "1821",
            "1823",
            "2632",
            "2633",
            "1546",
            "1489",
            "1822",
            "1761",
            "1764",
            "1488",
            "1825",
            "1828",
            "1747",
            "1490",
            "1820",
            "1824",
            "1768",
            "1767",
            "2644"
        };
        public List<string> FlooringCodes = new List<string>
        {
            "1071",
            "1072",
            "1073",
            "1074",
            "1075",
            "1076",
            "1077",
            "1078",
            "1079",
            "1080",
            "1081",
            "1082",
            "1083",
            "1085",
            "1086",
            "1087",
            "1088",
            "1089",
            "1141",
            "2970",
            "2971",
            "2972",
            "2973",
            "2974",
            "2975",
            "2976",
            "2977",
            "2978",
            "2979",
            "2980",
            "2981",
            "2982",
            "2983",
            "2984",
            "2985",
            "2986",
            "2987",
            "2988"
        };

        public List<string> BathTapCodes = new List<string>
        {
            "1009",
            "1011",
            "1030",
            "1032",
            "1027",
            "1028",
            "1012",
            "1031"
        };

        public List<string> BathCodes = new List<string>
        {
            "1762",
            "1763",
            "2630",
            "2662",
            "2663",
            "2649",
            "2631",
            "1708",
            "1709"
        };


        private void CbAssetFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item itm = (Item)cbAssetFamily.SelectedItem;

            lblAsstCopyFamilyCode.Content = itm.FamilyCode;

            cbCodes.Items.Clear();

            if (cbAssetFamily.SelectedItem.ToString() == "Towel Rail")
            {
                foreach (string trad in TradCodes)
                {
                    cbCodes.Items.Add(trad);
                }
            }
            else if (cbAssetFamily.SelectedItem.ToString() == "Wall Tiles")
            {
                foreach (string walltile in WallTileCodes)
                {
                    cbCodes.Items.Add(walltile);
                }
            }
            else if (cbAssetFamily.SelectedItem.ToString() == "Flooring")
            {
                foreach (string floor in FlooringCodes)
                {
                    cbCodes.Items.Add(floor);
                }
            }
            else if (cbAssetFamily.SelectedItem.ToString() == "Bath Tap")
            {
                foreach (string btap in BathTapCodes)
                {
                    cbCodes.Items.Add(btap);
                }
            }
            else if (cbAssetFamily.SelectedItem.ToString() == "Basin Tap")
            {
                foreach (string bsntap in BasinTapCodes)
                {
                    cbCodes.Items.Add(bsntap);
                }
            }
            else if (cbAssetFamily.SelectedItem.ToString() == "Tile Trim")
            {
                foreach (string ttrim in TileTrimCodes)
                {
                    cbCodes.Items.Add(ttrim);
                }
            }
            else if (cbAssetFamily.SelectedItem.ToString() == "Wash Basin/Vanity")
            {
                foreach (string pack in PackageCodes)
                {
                    cbCodes.Items.Add(pack);
                }

            }
            else if (cbAssetFamily.SelectedItem.ToString() == "Bath")
            {
                foreach (string bath in BathCodes)
                {
                    cbCodes.Items.Add(bath);
                }
            }







            cbCodes.SelectedIndex = 0;

        }

        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {
            if (tbAssetCopyCode.Text.Length != 4)
            {
                MessageBox.Show("Inccorect code", "Error", MessageBoxButton.OK);
                return;
            }
            foreach (string err in cbCodes.Items)
            {
                if (err == tbAssetCopyCode.Text)
                {
                    MessageBox.Show("Inccorect code", "Error", MessageBoxButton.OK);
                    return;
                }
            }

            runCopyFunction();

        }

        public void runCopyFunction()
        {
            try
            {
                var directories = Directory.GetDirectories(tbRootFolder.Text);

                Item itm = (Item)cbAssetFamily.SelectedItem;

                foreach (var topdir in directories)
                {
                    var subdirectories = Directory.GetDirectories(topdir, "*", SearchOption.AllDirectories);

                    foreach (var fldr in subdirectories)
                    {
                        DirectoryInfo fldrpath = new DirectoryInfo(fldr.ToString());

                        int filecount = Directory.EnumerateFiles(fldr).Count();

                        if (filecount == 0)
                        {

                        }
                        if (filecount > 1)
                        {
                            FileInfo[] fileswithcode = fldrpath.GetFiles("*" + itm.FamilyCode + "_" + cbCodes.Text + "*");
                            string copydir = @"\\bcluster\burrows\digital\autorender\taylorwimpey\Production\Bathroom\Assets\Final\Copy";


                            if (fileswithcode.Length >= 1)
                            {

                                if (!Directory.Exists(copydir))
                                {
                                    Directory.CreateDirectory(copydir);
                                }

                                foreach (FileInfo f in fileswithcode)
                                {
                                    string newname = f.Name.Replace(cbCodes.Text.ToString(), tbAssetCopyCode.Text.ToString());



                                    File.Copy(f.FullName, copydir + "\\" + newname);

                                }

                            }




                        }
                    }
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK);
                return;
            }

        }
        private void TbAssetCopyCode_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbAssetCopyCode.Text == "Add Code to copy to")
            { tbAssetCopyCode.Text = ""; }
            
        }
    }
}
