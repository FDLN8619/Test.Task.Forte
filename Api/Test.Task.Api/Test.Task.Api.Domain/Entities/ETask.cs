using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Task.Api.Domain.Enums;

namespace Test.Task.Api.Domain.Entities
{
    public class ETask
    {

        public int Id { get; set; }
        [MaxLength(250)]
        public string? Tittle { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public Status EStatus {get;set;}
        public virtual string EStatusString
        {
            get { return EStatus.ToString(); }
            set
            {
                Status newValue;
                if (Enum.TryParse(value, out newValue))
                { EStatus = newValue; }
            }
        }
        public DateTime? CreateDate { get; set; }        

    }
}
