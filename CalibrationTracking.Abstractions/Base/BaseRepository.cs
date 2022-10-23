using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CalibrationTracking.Abstractions.Base
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <seealso cref="Interfaces.IBaseRepository&lt;T, TContext&gt;" />
    public abstract class BaseRepository<T, TContext> : IBaseRepository<T, TContext>
        where TContext : DbContext
        where T : class, new()
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly TContext _context;

        /// <summary>
        /// The database set
        /// </summary>
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T, TContext}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">context</exception>
        protected BaseRepository(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public TContext Context => _context;

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">entity</exception>
        public async Task<T> CreateAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbSet.AddAsync(entity);

            return entity;
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException">entity</exception>
        public async Task DeleteAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Remove(entity);

            await Task.CompletedTask;
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public virtual Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        /// <summary>
        /// Singles the or default asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// id
        /// or
        /// T
        /// </exception>
        public async Task<T> GetById(int id = 0)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(T));
            }

            return entity;
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">entity</exception>
        public async Task<T> UpdateAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Update(entity);

            return await Task.FromResult(entity);
        }

        public async Task SaveChangesAsync()
        {
            await SaveChangesAsync();
        }
    }
}