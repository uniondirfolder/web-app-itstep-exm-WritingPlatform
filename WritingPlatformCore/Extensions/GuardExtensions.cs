

using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Linq;
using WritingPlatformCore.Entities.CabinetAggregate;
using WritingPlatformCore.Exceptions;

namespace WritingPlatformCore.Extensions
{
    public static class GuardExtensions
    {
        public static void NullCabinet(this IGuardClause guardClause, int cabinetId, Cabinet cabinet) 
        {
            if (cabinet == null)
                throw new CabinetNotFoundException(cabinetId);
        }

        public static void EmptyCabinetOnReadingException(this IGuardClause guardClause, IReadOnlyCollection<CabinetItem> cabinetItems)
        {
            if (!cabinetItems.Any())
                throw new EmptyCabinetOnReadingException();
        }
    }
}
