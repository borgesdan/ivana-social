using System;
using System.ComponentModel.DataAnnotations;

namespace Ivana.Data.Entities
{
    public class FamilyCompositionEntity
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string? Name { get; set; }

        public FamilyCompositionRelationshipType Relationship { get; set; }

        public DateTime? BirthDate { get; set; }

        public FamilyCompositionEducationType Education { get; set; }

        public GenderType Gender { get; set; }

        public string? Observations { get; set; }
    }
}
