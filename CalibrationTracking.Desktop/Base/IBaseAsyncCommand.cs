using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalibrationTracking.Desktop.Base
{
    /// <summary>
    /// Defines a command that executes an asynchronous method.
    /// </summary>
    public interface IAsyncCommand : ICommand
    {
        /// <summary>
        /// Gets a value indicating whether a task executed by this command is still running.
        /// </summary>
        IEnumerable<Task> RunningTasks
        {
            get;
        }

        /// <inheritdoc cref="ICommand.CanExecute" />
        bool CanExecute();

        /// <summary>
        /// Defines an asynchronous method to be called when the command is invoked.
        /// </summary>
        /// <returns>Returns an asynchronous operation.</returns>
        Task ExecuteAsync();
    }

    /// <summary>
    /// Defines a command that executes an asynchronous method.
    /// </summary>
    /// <typeparam name="T">The parameter type of the asynchronous method argument.</typeparam>
    public interface IAsyncCommand<in T> : ICommand
    {
        /// <summary>
        /// Gets a value indicating whether a task executed by this command is still running.
        /// </summary>
        IEnumerable<Task> RunningTasks
        {
            get;
        }

        /// <inheritdoc cref="ICommand.CanExecute" />
        bool CanExecute(T parameter);

        /// <summary>
        /// Defines an asynchronous method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">A value that is passed to the method when the command is invoked.</param>
        /// <returns>Returns an asynchronous operation.</returns>
        Task ExecuteAsync(T parameter);
    }
}