namespace LaptopListingSystem.Web.InputModels.Comments
{
    public class CommentInputModel
    {
        public int LaptopId { get; set; }

        // TODO Add validation
        public string Content { get; set; }
    }
}
