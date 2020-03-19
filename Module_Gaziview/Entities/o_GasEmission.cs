using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SynapseCore.Entities;
using System.Windows.Forms;

namespace Module_Gaziview.Entities
{
    public class o_GasEmission:SynapseEntity<o_GasEmission>
    {
        private static string _query = "SELECT * FROM [Gaziview_VW_GasEmission]";
        private static string _tableName = "[Gaziview_GasEmission]";
        private static string _IDproperty = "ID";
        private static string _EcludeForSave = "|BackgroundNoise|DetectionLimit|BackgroundNoiseEmission|NetEmission|Decision|MinEmissionDecl|EmissionDecl|MinDecl|WeekNr|LoadSuccessful|";

        private bool? _HS;
        private double _GasEmission;
        private double _GasVolume;
        private bool? _ConstantLoaded;
        //private o_Constant _ChainConstant = null;
        public o_GasEmission()
        {
            _ConstantLoaded = false;
        }

        public Int64 ID { get; set; }
        public Int64 ChainID { get; set; }
        public DateTime Date { get; set; }
        public double GasEmission
        { get { return _HS.HasValue&&_HS.Value?_SisterEmission.GasEmission:_GasEmission; } set {
            //if (!Valid)
            //{
                _GasEmission = value;
                if (_HS.HasValue&&_HS.Value)
                {
                    _HS = false;
                    _ConstantLoaded = false;
                    CheckConstant();
                }
                _HS = false;
            //}
            //else
            //    throw new Exception();
        } }
        public double GasVolume
        {
            get { return _HS.HasValue && _HS.Value ? _SisterEmission.GasVolume : _GasVolume; }
            set
            {
            //if (!Valid)
            //{
                _GasVolume = value;
                if (_HS.HasValue && _HS.Value)
                {
                    _HS = false;
                    _ConstantLoaded = false;
                    CheckConstant();
                }
                _HS = false;
            //}
            //else
            //    throw new Exception();
        }
        }
        public DateTime ValidationDate { get; set; }
        public DateTime EncodedDate { get; set; }
        public string ValidationBy { get; set; }
        public string EncodedBy { get; set; }


        public bool HS
        {
            get { return _HS.HasValue?_HS.Value:false; }
            set
            {
                bool? oldHS = _HS;
                if (oldHS != value && value == false)
                {
                    _ConstantLoaded = false;
                    CheckConstant();
                }
                _HS = value;
                if (_HS.HasValue && _HS.Value==true)
                {
                    //this.dump();
                    string queryGE = "SELECT     dbo.Gaziview_VW_GasEmission.* " +
                                     "FROM         dbo.Gaziview_VW_GasEmission INNER JOIN " +
                                     "dbo.Gaziview_Chain ON dbo.Gaziview_VW_GasEmission.ChainID = dbo.Gaziview_Chain.SisterID " +
                                     "WHERE dbo.Gaziview_Chain.ID = " + ChainID + " and Date = '" + Date.ToString("yyyy-MM-dd") + "'";
                    string queryC = "SELECT     dbo.Gaziview_Chain.ID, dbo.Gaziview_Chain.UnitID, dbo.Gaziview_Chain.Name, dbo.Gaziview_Chain.SisterID " +
                                    "FROM         dbo.Gaziview_Chain INNER JOIN " +
                                    "dbo.Gaziview_Chain AS Gaziview_Chain_1 ON dbo.Gaziview_Chain.ID = Gaziview_Chain_1.SisterID " +
                                    "WHERE     (Gaziview_Chain_1.ID = "+this.ChainID+")";
                    _SisterChain = o_Chain.LoadFromQuery(queryC).SingleOrDefault();
                    _SisterEmission = o_GasEmission.LoadFromQuery(queryGE).SingleOrDefault();
                    if (_SisterChain != null && _SisterEmission != null)
                    {
                        //this._GasEmission = SisterEmission.GasEmission;
                        //this._GasVolume = SisterEmission.GasVolume;
                        //this._BackgroundNoise = SisterEmission.BackgroundNoise;
                        //this._DetectionLimit = SisterEmission.DetectionLimit;
                        //this.Remarque = SynapseCore.Controls.SynapseForm.GetLabel("messages.valuesfrom") +" "+ SisterChain.Name;
                        //this.HSChainID = SisterChain.ID;
                        //this.LoadSuccessful = SisterEmission.LoadSuccessful;
                    }
                    else
                    {
                        MessageBox.Show(SynapseCore.Controls.SynapseForm.GetLabel("messages.errornosisterdata"));
                        _HS = oldHS;
                    }
                    // test hce339 this.ComputeHash();
                }
  
                //_ChainConstant = null;
            //MessageBox.Show("NO");
        } }

        private Int64 _HSChainID;
        public Int64 HSChainID { get { return _HS.HasValue && _HS.Value ? _SisterChain.ID : _HSChainID; } set { _HSChainID = value; } }
        private string _Remarque;
        public string Remarque
        {
            get
            { return _HS.HasValue && _HS.Value ? SynapseCore.Controls.SynapseForm.GetLabel("messages.valuesfrom") + " " + _SisterChain.Name : _Remarque; }
            set
            { _Remarque = value;
            //if (_HS.HasValue && _HS.Value)
            //{
            //    _HS = false;
            //    _ConstantLoaded = false;
            //    CheckConstant();
            //}
            //_HS = false;
            
            }
        }
        public bool Valid { get; set; }

        private o_GasEmission _SisterEmission;
        private o_Chain _SisterChain;



        private void CheckConstant()
        {
            if (_ConstantLoaded.HasValue&&_ConstantLoaded.Value==false)
            {
                _ConstantLoaded = true;
                if (!HS)
                {
                    o_Constant _ChainConstant = Helper.AllConstants.SingleOrDefault(c => c.ChainID == ChainID && Date >= c.DateFrom && Date <= c.DateTo);
                    if (_ChainConstant != null)
                    {
                        BackgroundNoise = _ChainConstant.BackgroundNoise;
                        DetectionLimit = _ChainConstant.DetectionLimit;
                        LoadSuccessful = true;
                    }
                    else
                    {
                        LoadSuccessful = false;
                        //MessageBox.Show("Unable to load constants, values will not be calculated");
                    }
                }
            }
        }


        #region Calculated Properties
        private bool _LoadSuccessful;
        public bool LoadSuccessful { get { return _HS.HasValue && _HS.Value ? _SisterEmission.LoadSuccessful : _LoadSuccessful; } set { _LoadSuccessful = value; } }
        private double? _BackgroundNoise = null;
        private double? _DetectionLimit = null;
        public double BackgroundNoise {
            get {
                if (_HS.HasValue&&_HS.Value)
                { return _SisterEmission.BackgroundNoise; }
                else
                {
                CheckConstant();
                return _BackgroundNoise.HasValue?_BackgroundNoise.Value:0;}
            }
            set { _BackgroundNoise = value; }
        }
        public double DetectionLimit {
            get {
                if (_HS.HasValue && _HS.Value)
                { return _SisterEmission.DetectionLimit; }
                else
                {
                CheckConstant();
            return _DetectionLimit.HasValue ? _DetectionLimit.Value : 0;
                }
            }
            set { _DetectionLimit = value; }
        }
        public double BackgroundNoiseEmission
        {
            get
            {
                CheckConstant();
                return BackgroundNoise*GasVolume;
            }
        }
        public double NetEmission
        {
            get
            {
                CheckConstant();
                return Math.Max(0, GasEmission - BackgroundNoiseEmission);
            }
        }
        public double Decision
        {
            get
            {
                CheckConstant();
                return DetectionLimit/2;
            }
        }
        public double MinEmissionDecl
        {
            get
            {
                CheckConstant();
                return (DetectionLimit / 4)*GasVolume;
            }
        }
        public double EmissionDecl
        {
            get
            {
                CheckConstant();
                if (NetEmission >= MinEmissionDecl)
                    return NetEmission;
                else
                    return MinEmissionDecl;
                

                }
        }
        public bool MinDecl
        {
            get
            {
                CheckConstant();
                return NetEmission < MinEmissionDecl;
            }
        }
        public int WeekNr{
            get { return Helper.GetWeekNr(Date); }
        }

        #endregion


    }
}
