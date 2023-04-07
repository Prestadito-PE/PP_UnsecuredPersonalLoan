using MongoDB.Bson.Serialization.Attributes;
using Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Core;

namespace Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Entities
{
    public class PersonalEntity : BaseAuditEntity
    {
        [BsonElement("strDoi")]
        public string StrDoi { get; set; }

        [BsonElement("dblPrincipal")]
        public decimal DblPrincipal { get; set; }

        //Tasa Efectiva Anual
        [BsonElement("dblApr")]
        public decimal DblApr { get; set; }

        //Tasa de Costo Efectiva Anual
        [BsonElement("dblEacr")]
        public decimal DblEacr { get; set; }

        [BsonElement("intMonths")]
        public short IntMonths { get; set; }

        [BsonElement("strLoanNumber")]
        public string StrLoanNumber { get; set; }

        [BsonElement("dteLoanStart")]
        public DateTime DteLoanStart { get; set; }

        //Fecha fin
        [BsonElement("dteMaturity")]
        public DateTime? DteMaturity { get; set; }
    }
}
