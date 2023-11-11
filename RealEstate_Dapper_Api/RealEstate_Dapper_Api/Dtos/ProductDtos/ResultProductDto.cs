namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City{ get; set; }
        public string District { get; set; }
        public int ProductCategory{ get; set; }
        public string CoverImg { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int EmployeeID { get; set; }

    }
}
