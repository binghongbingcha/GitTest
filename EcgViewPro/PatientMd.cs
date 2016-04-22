using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace EcgViewPro
{
    public class PatientMd
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PatientID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string Folk { get; set; }
        /// <summary>
        /// 身份证ID
        /// </summary>
        public string P_Id { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 签证机关
        /// </summary>
        public string Agency { get; set; }
        /// <summary>
        /// 有效期的开始时间
        /// </summary>
        public string ExpireStart { get; set; }
        /// <summary>
        /// 有效期的结束时间
        /// </summary>
        public string ExpireEnd { get; set; }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string WorkUnits { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 文化程度
        /// </summary>
        public string Levelofeducation { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string Marriage { get; set; }
        /// <summary>
        /// 常住类型
        /// </summary>
        public string PermanentType { get; set; }
        /// <summary>
        /// 血型
        /// </summary>
        public string BloodType { get; set; }
        /// <summary>
        /// 睡眠情况
        /// </summary>
        public string SleepStatus { get; set; }
        /// <summary>
        /// 体育锻炼
        /// </summary>
        public string PhysicalExercise { get; set; }
        /// <summary>
        /// 饮酒情况
        /// </summary>
        public string Drinking { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        public string Professional { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// 腰围
        /// </summary>
        public string Waistline { get; set; }
        /// <summary>
        /// 臀围
        /// </summary>
        public string Hipline { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        /// 残疾情况
        /// </summary>
        public string DisabilityStatus { get; set; }
        /// <summary>
        /// 药物过敏史
        /// </summary>
        public string Allergy { get; set; }
        /// <summary>
        /// 暴露史
        /// </summary>
        public string ExposureHistory { get; set; }
        /// <summary>
        /// 疾病史
        /// </summary>
        public string DiseasesHistory { get; set; }
        /// <summary>
        /// 手术史
        /// </summary>
        public string OperationHistory { get; set; }
        /// <summary>
        /// 外伤史
        /// </summary>
        public string RtaumaHistory { get; set; }
        /// <summary>
        /// 输血史
        /// </summary>
        public string TransfusionHistory { get; set; }

        /// <summary>
        /// 年龄开始
        /// </summary>
        public string AgeStart { get; set; }
        /// <summary>
        /// 年龄结束
        /// </summary>
        public string AgeEnd { get; set; }
        /// <summary>
        /// 采集开始时间
        /// </summary>
        public string CollectionStartDate { get; set; }
        /// <summary>
        /// 采集结束时间
        /// </summary>
        public string ConllectionEndDate { get; set; }

        /// <summary>
        /// 采集时间
        /// </summary>
        public string WardshipId { get; set; }
        /// <summary>
        /// 申请ID
        /// </summary>
        public string AppId { get; set; }

   /// <summary>
   /// 判读状态
   /// </summary>
        public string Pdstatus { get; set; }

    /// <summary>
    /// 
    /// </summary>
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
}
