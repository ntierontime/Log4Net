namespace Log4Net.EntityFrameworkContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dbo.Log")]
    public partial class Log
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Log ()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public System.Int64 Id { get; set; }

        public System.DateTime Date { get; set; }

        [Required]
        [StringLength(255)]
        public System.String Thread { get; set; }

        [Required]
        [StringLength(50)]
        public System.String Level { get; set; }

        [Required]
        [StringLength(255)]
        public System.String Logger { get; set; }

        [Required]
        [StringLength(4000)]
        public System.String Message { get; set; }

        [StringLength(2000)]
        public System.String Exception { get; set; }

    }
}

