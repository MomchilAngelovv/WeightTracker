using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WeightTracker.Data
{
    public class Weight
    {
        public Weight()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        [Column(TypeName = "decimal(10, 4)")]
        public decimal Kilograms { get; set; }
        public DateTime CreatedOn { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
