using ecomerce.api.Data;
using ecomerce.api.Repositories.Interfaces;
using ecomerce.shared.Response;
using Microsoft.EntityFrameworkCore;

namespace ecomerce.api.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext dataContext;

    public DbSet<T> entity { get; }

    public GenericRepository(DataContext dataContext)
    {
        this.dataContext = dataContext;
        this.entity = this.dataContext.Set<T>();
    }

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
        => new ActionResponse<IEnumerable<T>>()
        {
            WasSuccess = true,
            Result = await this.entity.ToListAsync()
        };

    public virtual async Task<ActionResponse<T>> AddAsync(T entity)
    {
        try
        {
            this.dataContext.Add<T>(entity);
            await this.dataContext.SaveChangesAsync();
            return new ActionResponse<T>()
            {
                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception ex)
        {

            return ExceptionActionResponse(ex);
        }
    }

    public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
    {
        var row = await this.entity.FindAsync(id);
        if (row is null)
        {
            return new ActionResponse<T>()
            {
                Message = "Data not found"
            };
        }

        try
        {
            this.dataContext.Remove(row);
            this.dataContext.SaveChanges();
            return new ActionResponse<T>()
            {
                WasSuccess = true
            };
        }
        catch
        {
            return new ActionResponse<T>()
            {
                Message = "Error while deleting data."
            };
        }
    }

    public virtual async Task<ActionResponse<T>> GetAsync(int id)
    {
        var row = await this.entity.FindAsync(id);
        if (row is null)
        {
            return new ActionResponse<T>()
            {
                Message = "Data not found"
            };
        }

        return new ActionResponse<T>()
        {
            WasSuccess = true,
            Result = row
        };
    }

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
    {
        try
        {
            this.dataContext.Update<T>(entity);
            await this.dataContext.SaveChangesAsync();
            return new ActionResponse<T>()
            {
                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception ex)
        {

            return ExceptionActionResponse(ex);
        }
    }

    #region Private
    private ActionResponse<T> ExceptionActionResponse(Exception ex)
    {
        return new ActionResponse<T>()
        {
            Message = ex.Message
        };
    }

    private ActionResponse<T> DbUpdateExceptionActionResponse()
    {
        return new ActionResponse<T>()
        {
            Message = "Data already exis."
        };
    }
    #endregion
}
