
namespace smartservicesapp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;


    #region Registration
    [DataContract]
    [Table("UserRegister")]
    public partial class UserRegister
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
        public DateTime CreateDate { get; set; }
        [DataMember]
        public int FileId { get; set; }
        [DataMember]
        [NotMapped]
        public byte[] FileName { get; set; }
        [DataMember]
        [NotMapped]
        public string FilePathName { get; set; }

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
        public int CatOrderBy { get; set; }
        [DataMember]
        public string CatClassName { get; set; }
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
        public int PrivacyOrderBy { get; set; }

        [DataMember]
        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string PrivacyTypeName { get; set; }
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }


    }

    #endregion

    [DataContract]
    public class AddBlog
    {

        [DataMember]
        [Key]
        public int BlogId { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public int PrivacyID { get; set; }
        [DataMember]
        [Column(TypeName = "text")]
        public string textContent { get; set; }
        [DataMember]
        public string UserLikes { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime UpdatedDate { get; set; }
        [DataMember]
        [NotMapped]
        public List<string> Fileinfo { get; set; }
        [DataMember]
        [NotMapped]
        public List<UserRegister> Userinfo { get; set; }

    }
    [DataContract]
    public class BlogDocument
    {

        [DataMember]
        [Key]
        public int DocumentId { get; set; }
        public int BlogId { get; set; }
        [DataMember]
        public int FileID { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
    }
    #region uploadfile

    [DataContract]
    public class FileSetting
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        public string FileType { get; set; }

        [DataMember]
        [Column(TypeName = "int")]
        public int SourceID { get; set; }

        //[DataMember]
        //[Column(TypeName = "image")]
        //public byte[] File { get; set; }

        [DataMember]
        [Column(TypeName = "varchar(max)")]
        public string FilePath { get; set; }

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

    [DataContract]
    public class BlogComment
    {
       
        [Key] 
        [DataMember]
        public int CommentId { get; set; } 
        [DataMember]
        public int BlogId { get; set; }
        [DataMember]
        [Column(TypeName = "text")]
        public string Comment { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
    }





}