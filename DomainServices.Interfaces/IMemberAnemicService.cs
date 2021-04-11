using Domain.Entities;


namespace DomainServices.Interfaces
{
    public interface IMemberAnemicService
    {
        decimal GetRating(Member member, SomethingNDeliveryDelegate something);
    }
}
