using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Module_Gaziview.Entities;

namespace Module_Gaziview
{
    public partial class frm_ImportOldData : Form
    {
        IList<o_Unit> Units;
        IList<o_Chain> Chains;
        List<o_Constant> Constants = new List<o_Constant>();
        List<o_GasEmission> Emissions = new List<o_GasEmission>();
        List<KeyValuePair<string,string>> trancheequiv = new List<KeyValuePair<string,string>>();
        public frm_ImportOldData()
        {
            InitializeComponent();
            Units = o_Unit.Load();
            Chains = o_Chain.Load();
            trancheequiv.Add(new KeyValuePair<string,string>("Tihange 1","1"));
            trancheequiv.Add(new KeyValuePair<string,string>("Tihange 2","2"));
            trancheequiv.Add(new KeyValuePair<string,string>("Tihange 3","3"));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\hce339\Desktop\GAZIVIEW_DATA.accdb"))
            {
                conn.Open();
                foreach (o_Unit u in Units)
                {
                    string unitstr = trancheequiv.SingleOrDefault(te=>te.Key==u.Name).Value;
                    o_Constant CurrentConstant=new o_Constant();
                    foreach (o_Chain c in Chains.Where(ch => ch.UnitID == u.ID))
                    {
                        int rowcount=0;
                        using (OleDbCommand cmd = new OleDbCommand("SELECT Rejet.*, Chaine.NomChaine FROM Chaine INNER JOIN Rejet ON Chaine.IdChaine = Rejet.IdChaine WHERE Chaine.NomChaine='"+c.Name+"' AND Chaine.NomTranche='"+unitstr+"' ORDER BY DateRejet", conn))
                        {
                            bool CurrentActive = false;

                            OleDbDataReader Reader = cmd.ExecuteReader();
                            //if (Reader.HasRows)
                            if (Reader.HasRows)
                            {
                                while (Reader.Read())
                                {
                                    DateTime Date = ((DateTime)Reader["DateRejet"]).AddDays(-1);
                                    double RejetGaz = Convert.ToDouble(Reader["RejetGaz24h"] is DBNull ? 0 : Reader["RejetGaz24h"]);
                                    double VolumeGaz = Convert.ToDouble(Reader["VolumeGaz24h"] is DBNull?0:Reader["VolumeGaz24h"]);
                                    string Remarque = Reader["Remarque"].ToString();
                                    double Bdf = Convert.ToDouble(Reader["BDFRejet"] is DBNull ? 0 : Reader["BDFRejet"]);
                                    double SeuilDecision = Convert.ToDouble(Reader["SeuilDecision"] is DBNull ? 0 : Reader["SeuilDecision"]);
                                    string Trigramme = Reader["Trigramme"].ToString();
                                    double LimitDetection = SeuilDecision * 2;
                                    if (CurrentActive == false)
                                    {
                                        CurrentConstant = new o_Constant() { ChainID = c.ID, BackgroundNoise = Bdf, DetectionLimit = LimitDetection, DateFrom = Date, DateTo = Date };
                                        CurrentActive = true;
                                    }
                                    if (CurrentConstant.BackgroundNoise == Bdf && CurrentConstant.DetectionLimit == LimitDetection)
                                    {
                                        CurrentConstant.DateTo = Date;
                                    }
                                    else
                                    {
                                        Constants.Add(CurrentConstant);
                                        CurrentConstant = new o_Constant() { ChainID = c.ID, BackgroundNoise = Bdf, DetectionLimit = LimitDetection, DateFrom = Date, DateTo = Date };
                                    }
                                    Emissions.Add(new o_GasEmission() { Date = Date, ChainID = c.ID, Remarque = Remarque, EncodedDate = Date.AddDays(1), EncodedBy = Trigramme, Valid=true, ValidationBy="System", ValidationDate= Date.AddDays(2), GasEmission=RejetGaz, GasVolume=VolumeGaz });

                                  
                                    rowcount++;
                                }
                                CurrentConstant.DateTo = DateTime.MaxValue;
                                Constants.Add(CurrentConstant);
                            }
                        }
                        richTextBox1.AppendText(string.Format("Unité {0} Chaine {1} : {2} Rejets chargés / {3} Constante créées / {4} Rejets importés\n",u.Name ,c.Name, rowcount, Constants.Where(co=>co.ChainID==c.ID).Count(), Emissions.Where(em=>em.ChainID==c.ID).Count()));
                        this.Refresh();
                        this.Update();
                    }
                }
                
                List<KeyValuePair<string,string>> trigtouser = new List<KeyValuePair<string,string>>();
                trigtouser.Add(new KeyValuePair<string, string>("ah", "CORP\\ADH220"));
                trigtouser.Add(new KeyValuePair<string,string>("arv","CORP\\CHG415"));
                trigtouser.Add(new KeyValuePair<string, string>("BES", "CORP\\FGJ032"));
                trigtouser.Add(new KeyValuePair<string, string>("CLA", "CORP\\AAJ475"));
                trigtouser.Add(new KeyValuePair<string, string>("dcp", "CORP\\EGF093"));
                trigtouser.Add(new KeyValuePair<string, string>("dgl", "CORP\\EDB021"));
                trigtouser.Add(new KeyValuePair<string, string>("dns", "CORP\\ECC007"));
                trigtouser.Add(new KeyValuePair<string, string>("drg", "CORP\\CIK103"));
                trigtouser.Add(new KeyValuePair<string, string>("EHE", "CORP\\CAJ200"));
                trigtouser.Add(new KeyValuePair<string, string>("gsb", "CORP\\EIH005"));
                trigtouser.Add(new KeyValuePair<string, string>("gsn", "CORP\\GEJ361"));
                trigtouser.Add(new KeyValuePair<string, string>("HEL", "CORP\\FJH023"));
                trigtouser.Add(new KeyValuePair<string, string>("Lah", "CORP\\ADH220"));
                trigtouser.Add(new KeyValuePair<string, string>("lbm", "CORP\\GBC037"));
                trigtouser.Add(new KeyValuePair<string, string>("LPN", "CORP\\AFE434"));
                trigtouser.Add(new KeyValuePair<string, string>("nlf", "CORP\\EJB173"));
                trigtouser.Add(new KeyValuePair<string, string>("ost", "CORP\\BJD405"));
                trigtouser.Add(new KeyValuePair<string, string>("urm", "CORP\\IGA484"));
                trigtouser.Add(new KeyValuePair<string, string>("vhp", "CORP\\HAL173"));

                foreach (o_GasEmission E in Emissions)
                {
                    E.EncodedBy = trigtouser.SingleOrDefault(ttu => ttu.Key == E.EncodedBy).Value;
                }
                this.Refresh();
                this.Update();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SynapseCore.Database.DBFunction.ExecuteNonQuery("TRUNCATE TABLE Gaziview_Constant");
            SynapseCore.Database.DBFunction.ExecuteNonQuery("TRUNCATE TABLE Gaziview_GasEmission");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IList<o_GasEmission> GasEmissions = o_GasEmission.Load();
            int hscount = 0;
            foreach (o_GasEmission E in GasEmissions)
            {
               
                if (E.Remarque.Contains("Valeur"))
                {
                    E.HSChainID = Chains.Single(ch => ch.ID == E.ChainID).SisterID;
                    E.HS = true;
                    hscount++;
                    E.save();
                }
            }
            richTextBox1.AppendText(string.Format("nbr d'emission HS updatées:{0}\n", hscount));
            this.Refresh();
            this.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (o_Constant cst in Constants)
                cst.save();
            richTextBox1.AppendText(string.Format("{0} Constant saved\n", Constants.Count));
            this.Refresh();
            this.Update();
            foreach (o_GasEmission ge in Emissions)
                ge.save();
            richTextBox1.AppendText(string.Format("{0} Emission saved\n", Emissions.Count));
            this.Refresh();
            this.Update();
            
        }
    }
}
