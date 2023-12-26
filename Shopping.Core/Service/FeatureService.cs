

using Microsoft.EntityFrameworkCore;
using Shopping.Core.Interface;
using Shopping.Database.Context;
using Shopping.Database.Model;

namespace Shopping.Core.Service;

public class FeatureService : IFeature
{
    private readonly DatabaseContext _context;
    public FeatureService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> AddFeature(Feature feature)
    {
        try
        {
            await _context.Features.AddAsync(feature);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<bool> AddFeatureGroup(FeatureGroup featureGroup)
    {
        try
        {
            await _context.FeatureGroups.AddAsync(featureGroup);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<bool> AddFeatureSection(FeatureSection featureSection)
    {
        try
        {
            await _context.FeatureSections.AddAsync(featureSection);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<bool> DeleteFeature(int Id)
    {
        try
        {
            var feature = await _context.Features.FindAsync(Id);
            if (feature != null)
            {
                _context.Features.Remove(feature);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<bool> DeleteFeatureGroup(int Id)
    {
        try
        {
            var feature = await _context.FeatureGroups.FindAsync(Id);
            if (feature != null)
            {
                _context.FeatureGroups.Remove(feature);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }

    }

    public async Task<bool> DeleteFeatureSection(int Id)
    {
        try
        {
            var feature = await _context.FeatureSections.FindAsync(Id);
            if (feature != null)
            {
                _context.FeatureSections.Remove(feature);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async void Dispose()
    {
        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }

    public async Task<bool> EditFeature(Feature feature)
    {
        try
        {
            _context.Features.Update(feature);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            // throw;
        }
    }

    public async Task<bool> EditFeatureGroup(FeatureGroup featureGroup)
    {
        try
        {
            _context.FeatureGroups.Update(featureGroup);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }

    }

    public async Task<bool> EditFeatureSection(FeatureSection featureSection)
    {
        try
        {
            _context.FeatureSections.Update(featureSection);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
            //throw;
        }
    }

    public async Task<Feature> GetFeature(int Id)
    {
        var feature = await _context.Features.Include(f => f.FeatureSection).FirstOrDefaultAsync(f => f.Id == Id);
        return await Task.FromResult(feature);
    }

    public async Task<FeatureGroup> GetFeatureGroup(int Id)
    {

        var featureGroup = await _context.FeatureGroups.Include(f=>f.FeatureSections).FirstOrDefaultAsync(f=>f.Id==Id);
        if (featureGroup != null)
        {
            return await Task.FromResult(featureGroup);
        }
        return null;
    }

    public async Task<List<FeatureGroup>> GetFeatureGroups()
    {
        var featureGroups = await _context.FeatureGroups.Include(f => f.FeatureSections).ToListAsync();
        return await Task.FromResult(featureGroups);
    }

    public async Task<List<Feature>> GetFeatures()
    {
        var features = await _context.Features.Include(f => f.FeatureSection).ToListAsync();
        return await Task.FromResult(features);
    }

    public async Task<FeatureSection> GetFeatureSection(int Id)
    {
        var featureSection = await _context.FeatureSections.Include(f => f.FeatureGroup).FirstOrDefaultAsync(f => f.Id == Id);
        return await Task.FromResult(featureSection);
    }

    public async Task<List<FeatureSection>> GetFeatureSections()
    {
        var featureSections = await _context.FeatureSections.Include(f => f.FeatureGroup).Include(f => f.Features).ToListAsync();
        return await Task.FromResult(featureSections);
    }

    public async Task<List<Feature>> RelatedFeature(int Id)
    {
        var feature = await _context.Features.Include(f => f.FeatureSection).Where(f => f.FeatureSectionId == Id).ToListAsync();
        return await Task.FromResult(feature);
    }

    public async Task<List<FeatureSection>> RelatedFeatureSections(int Id)
    {
        var relatedfeature = await _context.FeatureSections.Include(f => f.FeatureGroup).Where(f => f.FeatureGroupId == Id).ToListAsync();
        return await Task.FromResult(relatedfeature);
    }
}
