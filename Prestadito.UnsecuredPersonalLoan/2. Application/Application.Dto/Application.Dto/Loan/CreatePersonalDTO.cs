namespace Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal
{
    public class CreatePersonalDTO
    {
        public string strDoi { get; set; }
        public decimal dblPrincipal { get; set; }
        //Tasa Efectiva Anual
        public decimal dblApr { get; set; }
        //Tasa de Costo Efectiva Anual
        public decimal dblEacr { get; set; }
        public short intMonths { get; set; }
        public string strLoanNumber { get; set; }
        public DateTime dteLoanStart { get; set; }
        //Fecha fin
        public DateTime? dteMaturity { get; set; }
    }
}
