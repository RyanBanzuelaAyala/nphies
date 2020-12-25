namespace QData.Repository.V3.Base
{
    using QData.Data;
    using System;

    /// <summary>
    /// Defines the <see cref="BaseBusiness" />.
    /// </summary>
    public abstract class BaseBusiness
    {
        /// <summary>
        /// Defines the Factory.
        /// </summary>
        protected readonly Func<AppsDbContext> Factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseBusiness"/> class.
        /// </summary>
        /// <param name="factory">The factory<see cref="Func{AppsDbContext}"/>.</param>
        public BaseBusiness(Func<AppsDbContext> factory)
        {
            Factory = factory;
        }
    }
}
