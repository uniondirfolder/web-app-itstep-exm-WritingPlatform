using System;


namespace WritingPlatformCore.Entities.CabinetAggregate
{
    public class CabinetItem: BaseEntity
    {
        public DateTimeOffset DateTimeCreate { get; private set; }
        public DateTimeOffset DateTimeModify { get; private set; }
        public int CatalogItemId { get; private set; }
        public int CabinetId { get; private set; }
        public CabinetItem(int catalogItemId)
        {
            CatalogItemId = catalogItemId;
            DateTimeCreate = DateTime.UtcNow;
            SetIsModify();
        }

        public void SetIsModify() 
        {
            DateTimeModify = DateTime.UtcNow;
        }


    }
}
