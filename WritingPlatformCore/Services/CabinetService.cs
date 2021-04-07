using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WritingPlatformCore.Entities.CabinetAggregate;
using WritingPlatformCore.Extensions;
using WritingPlatformCore.Interfaces;
using WritingPlatformCore.Specifications;

namespace WritingPlatformCore.Services
{
    public class CabinetService : ICabinetService
    {
        private readonly IAsyncRepository<Cabinet> _cabinetRepository;
        private readonly IAppLogger<CabinetService> _logger;
        public CabinetService(IAsyncRepository<Cabinet> cabinetRepository, IAppLogger<CabinetService> logger)
        {
            _cabinetRepository = cabinetRepository;
            _logger = logger;
        }



        public async Task AddItemToCabinet(int cabinetId, int catalogItemId)
        {
            var cabSpec = new CabinetWithItemsSpecification(cabinetId);
            var cabinet = await _cabinetRepository.FirstOrDefaultAsync(cabSpec);
            Guard.Against.NullCabinet(cabinetId, cabinet);

            cabinet.AddItem(catalogItemId, false);

            await _cabinetRepository.UpdateAsync(cabinet);
        }

        public async Task DeleteCabinetAsync(int cabinetId)
        {
            var cabinet = await _cabinetRepository.GetByIdAsync(cabinetId);
            await _cabinetRepository.DeleteAsync(cabinet);
        }

        public async Task SetDateTimeModify(int cabinetId, Dictionary<string, bool> compositions)
        {
            Guard.Against.Null(compositions, nameof(compositions));
            var cabSpec = new CabinetWithItemsSpecification(cabinetId);
            var cabinet = await _cabinetRepository.FirstOrDefaultAsync(cabSpec);
            Guard.Against.NullCabinet(cabinetId, cabinet);

            foreach (var item in cabinet.Items)
            {
                if(compositions.TryGetValue(item.Id.ToString(), out var change)) 
                {
                    if (_logger != null) _logger.LogInformation($"Updating state of item ID:{item.Id} to {change}.");
                    if (change) item.SetIsModify();
                }
            }
            cabinet.RemoveEmptyItems();
            await _cabinetRepository.UpdateAsync(cabinet);
        }

        public async Task TransferCabinetAsync(string anonymousId, string ownerName)
        {
            Guard.Against.NullOrEmpty(anonymousId, nameof(anonymousId));
            Guard.Against.NullOrEmpty(ownerName, nameof(ownerName));
            var anonymousCabSpec = new CabinetWithItemsSpecification(anonymousId);
            var anonymousCab = await _cabinetRepository.FirstOrDefaultAsync(anonymousCabSpec);
            if (anonymousCab == null) return;
            var ownerCabSpec = new CabinetWithItemsSpecification(ownerName);
            var ownerCab = await _cabinetRepository.FirstOrDefaultAsync(ownerCabSpec);
            if (ownerCab == null)
            {
                ownerCab = new Cabinet(ownerName);
                await _cabinetRepository.AddAsync(ownerCab);
            }
            foreach (var item in anonymousCab.Items)
            {
                ownerCab.AddItem(item.CatalogItemId, false);
            }
            await _cabinetRepository.UpdateAsync(ownerCab);
            await _cabinetRepository.DeleteAsync(anonymousCab);
        }
    }
}
