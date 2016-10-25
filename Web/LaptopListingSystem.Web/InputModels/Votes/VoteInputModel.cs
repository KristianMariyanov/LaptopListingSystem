namespace LaptopListingSystem.Web.InputModels.Votes
{
    using System.ComponentModel.DataAnnotations;

    public class VoteInputModel
    {
        [Range(1, int.MaxValue)] // TODO: Move to constants
        public int LaptopId { get; set; }
    }
}
