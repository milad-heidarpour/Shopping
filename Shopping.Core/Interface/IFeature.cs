
using Shopping.Database.Model;

namespace Shopping.Core.Interface;

public interface IFeature:IDisposable
{
    #region FEATURE GROUP
    Task<List<FeatureGroup>> GetFeatureGroups();
    Task<FeatureGroup> GetFeatureGroup(int Id);//Id ==Feature GroupId
    Task<bool> AddFeatureGroup(FeatureGroup featureGroup);
    Task<bool> EditFeatureGroup(FeatureGroup featureGroup);
    Task<bool> DeleteFeatureGroup(int Id);
    #endregion

    #region FEATURE SECTION
    Task<List<FeatureSection>> GetFeatureSections();
    Task<List<FeatureSection>> RelatedFeatureSections(int Id); //for getting feature sections with a feature groupId
    Task<FeatureSection> GetFeatureSection(int Id);//Id ==Feature SectionId
    Task<bool> AddFeatureSection(FeatureSection featureSection);
    Task<bool> EditFeatureSection(FeatureSection featureSection);
    Task<bool> DeleteFeatureSection(int Id);
    #endregion

    #region FEATURE
    Task<List<Feature>> GetFeatures();
    Task<Feature> GetFeature(int Id);
    Task<List<Feature>> RelatedFeature(int Id);
    Task<bool> AddFeature(Feature feature);
    Task<bool> EditFeature(Feature feature);
    Task<bool> DeleteFeature(int Id);
    #endregion
}
