namespace Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.UpdatePersonal
{
    public class UpdatePersonalRequest
    {
        public string Id { get; set; }
        public string StrDoi { get; set; }
        public decimal DblPrincipal { get; set; }
        //Tasa Efectiva Anual
        public decimal DblApr { get; set; }
        //Tasa de Costo Efectiva Anual
        public decimal DblEacr { get; set; }
        public short IntMonths { get; set; }
        public string StrLoanNumber { get; set; }
        public DateTime DteLoanStart { get; set; }
        //Fecha fin
        public DateTime? DteMaturity { get; set; }
        public bool BlnActive { get; set; }
    }
}
