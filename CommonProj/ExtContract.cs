using System;

namespace CommonProj
{
    /// <summary>
    /// 一体机合同
    /// </summary>
    public class ExtContract : ContractInfo
    {
        public Combination Others { get; set; }
    }

    /// <summary>
    /// 一体机除去心电外的扩展参数
    /// </summary>
    public class Combination
    {
        public string LEU { get; set; }

        public string NIT { get; set; }

        public string UBG { get; set; }

        public string PRO { get; set; }

        public string PH { get; set; }

        public string BLD { get; set; }

        public string KET { get; set; }

        public string BIL { get; set; }

        public string GLU { get; set; }

        public string VC { get; set; }

        public string SG { get; set; }

        public string Mmol { get; set; }

        public string Spo2 { get; set; }

        public string DIA { get; set; }

        public string SYS { get; set; }

        public string Temperature { get; set; }

    }

    public class QueryParams
    {
        public string CommunityId { get; set; }
        public string[] ContractIds { get; set; }

        /// <summary>
        /// 软件版本
        /// </summary>
         public string Version { get; set; }
    }


    /// <summary>
    /// 一体机返回的结果
    /// </summary>
    public class ExtResult
    {
        public string ContractId { get; set; }

        public DateTime BeginTime { get; set; }

        public string Diagnosis { get; set; }
    }

    /// <summary>
    /// 一体机返回的结果
    /// </summary>
    public class ExtRestResult
    {
        /// <summary>
        /// 静态合同
        /// </summary>
        public ExtResult[] Result { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Msg State { get; set; }

    }


}