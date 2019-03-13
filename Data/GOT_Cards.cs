namespace GotApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using GotApi.Models;

    
    public partial class GOT_Cards
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GOT_Cards()
        {
            GOT_InteractionLink = new HashSet<GOT_InteractionLink>();
            GOT_KeywordLink = new HashSet<GOT_KeywordLink>();
            GOT_ReactionLink = new HashSet<GOT_ReactionLink>();
            GOT_Restricted = new HashSet<GOT_Restricted>();
            GOT_RF_Alias = new HashSet<GOT_RF_Alias>();
            GOT_RF_Characters = new HashSet<GOT_RF_Characters>();
            GOT_RF_Plots = new HashSet<GOT_RF_Plots>();
            GOT_TraitLink = new HashSet<GOT_TraitLink>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short CardId { get; set; }

        [Required]
        [StringLength(50)]
        public string CardName { get; set; }

        public byte FactionId { get; set; }

        public bool Loyal { get; set; }

        public byte TypeId { get; set; }

        public bool Uniq { get; set; }

        public byte? Cost { get; set; }

        public byte SetId { get; set; }

        public virtual GOT_Sets GOT_Sets { get; set; }

        public virtual GOT_Types GOT_Types { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOT_InteractionLink> GOT_InteractionLink { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOT_KeywordLink> GOT_KeywordLink { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOT_ReactionLink> GOT_ReactionLink { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOT_Restricted> GOT_Restricted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOT_RF_Alias> GOT_RF_Alias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOT_RF_Characters> GOT_RF_Characters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOT_RF_Plots> GOT_RF_Plots { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOT_TraitLink> GOT_TraitLink { get; set; }

        public List<KirtObject> GeneralGet<T>() where T : class
        {
            return null;
        }

        public List<KirtObject> GetKeywords()
        {
            var keywordList = (from item in GOT_KeywordLink
                               select new KirtObject()
                               {
                                    ObjectId = item.KeywordId,
                                    ObjectName = item.GOT_Keywords2.KeywordName
                               }).ToList();

            return keywordList;
        }

        public List<KirtObject> GetInteractions()
        {
            var interactionList = (from item in GOT_InteractionLink
                                   select new KirtObject()
                                   {
                                        ObjectId = item.InteractionId,
                                        ObjectName = item.GOT_Interactions2.InteractionName
                                   }).ToList();

            return interactionList;
        }

        public List<KirtObject> GetReactions()
        {
            var reactionList = (from item in GOT_ReactionLink
                                select new KirtObject()
                                {
                                    ObjectId = item.ReactionId,
                                    ObjectName = item.GOT_Reactions2.ReactionName
                                }).ToList();

            return reactionList;
        }

        public List<KirtObject> GetTraits()
        {
            var traitList = (from item in GOT_TraitLink
                             select new KirtObject()
                             {
                                 ObjectId = item.TraitId,
                                 ObjectName = item.GOT_Traits2.TraitName
                             }).ToList();

            return traitList;
        }
    }
}
