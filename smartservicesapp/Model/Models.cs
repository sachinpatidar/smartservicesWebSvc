
namespace gmcscoServices.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;


    #region Registration
    [DataContract]
    [Table("UserRegister")]
    public class UserRegister
    {
        [Key]
        [DataMember]
        public int RegistrationID { get; set; }
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        [DataMember]
        public string FirstName { get; set; }
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        [DataMember]
        public string LastName { get; set; }
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        [DataMember]
        public string UserName { get; set; }
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        [DataMember]
        public string Email { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }

    }
    #endregion

    #region Login
    [DataContract]
    public class Login
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
    #endregion

    #region Category
    [DataContract]
    [Table("Category")]
    public class Category
    {
        [Key]
        [DataMember]
        public int CategoryID { get; set; }

        [DataMember]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string CategoryName { get; set; }
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }


    }
    #endregion
    #region PrivacyType
    [DataContract]
    [Table("PrivacyType")]
    public class PrivacyType
    {
        [Key]
        [DataMember]
        public int PrivacyID { get; set; }

        [DataMember]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string PrivacyTypeName { get; set; }
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }


    }

    #endregion
    #region ["Return Values"]
    [DataContract]
    public class ReturnValues
    {
        [DataMember]
        public string Success { get; set; }
        [DataMember]
        public string Failure { get; set; }

        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public bool Status { get; set; }


    }
    #endregion





}