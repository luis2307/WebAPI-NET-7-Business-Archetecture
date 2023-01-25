namespace Company.ProjectName.Application.DTO
{
    public class CategoriesDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string MyProperty { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public byte[] Picture { get; set; }
    }
}
