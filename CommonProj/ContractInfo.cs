namespace CommonProj
{
    //合同信息
    public class ContractInfo
    {
        public Patient God { get; set; }
        public EcgData[] Data { get; set; }
        public Transition Trans { get; set; }
        public Contract Contr { get; set; }
    }

    //患者对象
    public class Patient
    {
        public string PatientID { get; set; }//不能为空
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string InPatientNum { get; set; }
        public string BedNum { get; set; }
        public string Status { get; set; }
        public string IsQiBo { get; set; }
        public string RoomNum { get; set; }
        public string DiseaseHistory { get; set; }
        public string NewId { get; set; }
    }

    //临时表对象
    public class Transition
    {
        public string ApplicationID { get; set; }
        public string InptLevel { get; set; }
        public virtual string CheckDate { get; set; }
        public string CommunityOrgID { get; set; }
        public string GatherCompletionTime { get; set; }
    }

    public class Contract
    {
        public string Status { get; set; }
        public string ApplicationUserID { get; set; }
        public string ApplicationDate { get; set; }
    }

    //数据表信息
    public class EcgData
    {
        public string BeginTime { get; set; }
        public string PureData { get; set; }
        public string EcgFilter { get; set; }
        public string IsLead { get; set; }
        public string PaceLocs { get; set; }
    }

    public class RestingResult
    {
        /// <summary>
        /// 静态合同
        /// </summary>
        public EcgContract[] RestContracts { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public Msg State { get; set; }

    }

    public class EcgContract
    {
        public string DocName { get; set; }
        public string DocDept { get; set; }
        public string Hospital { get; set; }
        /// <summary>
        /// 医生编号用于获取电子签名
        /// </summary>
        public string DoctorId { get; set; }
        /// <summary>
        /// 导联纠错
        /// </summary>
        public string LeadCorrect { get; set; }
        /// <summary>
        /// 特别关注
        /// </summary>
        public string IsNoticed { get; set; }
        /// <summary>
        /// 返回的参数
        /// </summary>
        public DiagParam[] EcgDiagParams { get; set; }
        /// <summary>
        /// 返回的结论
        /// </summary>
        public Diagnosis[] EcgResult { get; set; }
        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractId { get; set; }

    }

    public class DiagParam
    {
        public string ContractId { get; set; }
        public string TimePoint { get; set; }
        public string Bmp { get; set; }
        public string Pr { get; set; }
        public string Qtc { get; set; }
        public string Rv5 { get; set; }
        public string Sv1 { get; set; }
        public string Qt { get; set; }
        /// <summary>
        /// 电轴
        /// </summary>
        public string Axis { get; set; }
        /// <summary>
        /// p波
        /// </summary>
        public string Pwave { get; set; }
        public string Qrs { get; set; }
        /// <summary>
        /// T波
        /// </summary>
        public string Twave { get; set; }
        /// <summary>
        /// 用于以后不变更接口返回
        /// </summary>
        public string Temp { get; set; }
    }

    public class Diagnosis
    {
        public string ContractId { get; set; }

        /// <summary>
        /// 病理标签点
        /// </summary>
        public string TimePoint { get; set; }
        /// <summary>
        /// 诊断结论
        /// </summary>
        public string Conclusion { get; set; }
    }

    public class Doctor
    {
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        /// <summary>
        /// BASE64电子签名
        /// </summary>
        public string Autograph { get; set; }
    }

    public class DoctorEx:Doctor
    {
        public byte[] Image2 { get; set; }
    }
}