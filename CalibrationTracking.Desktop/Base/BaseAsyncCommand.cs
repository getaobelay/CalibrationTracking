using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalibrationTracking.Desktop.Base
{
    /// <inheritdoc cref="IAsyncCommand" />
    public abstract class BaseAsyncCommand : IBaseAsyncCommand
    {
        private readonly ObservableCollection<Task> runningTasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAsyncCommand"/> class.
        /// </summary>
        protected BaseAsyncCommand()
        {
            runningTasks = new ObservableCollection<Task>();
            runningTasks.CollectionChanged += OnRunningTasksChanged;
        }

        /// <inheritdoc />
        public IEnumerable<Task> RunningTasks
        {
            get => runningTasks;
        }

        /// <inheritdoc />
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <inheritdoc />
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        /// <inheritdoc />
        public abstract bool CanExecute();

        /// <inheritdoc />
        async void ICommand.Execute(object parameter)
        {
            Task runningTask = ExecuteAsync();

            runningTasks.Add(runningTask);

            try
            {
                await runningTask;
            }
            finally
            {
                runningTasks.Remove(runningTask);
            }
        }

        /// <inheritdoc />
        public abstract Task ExecuteAsync();

        private void OnRunningTasksChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }

    /// <inheritdoc cref="IAsyncCommand{T}"/>
    public abstract class BaseAsyncCommand<T> : IAsyncCommand<T>
    {
        private readonly ObservableCollection<Task> runningTasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAsyncCommand{T}"/> class.
        /// </summary>
        protected BaseAsyncCommand()
        {
            runningTasks = new ObservableCollection<Task>();
            runningTasks.CollectionChanged += OnRunningTasksChanged;
        }

        /// <inheritdoc />
        public IEnumerable<Task> RunningTasks
        {
            get => runningTasks;
        }

        /// <inheritdoc />
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <inheritdoc />
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        /// <inheritdoc />
        public abstract bool CanExecute(T parameter);

        /// <inheritdoc />
        async void ICommand.Execute(object parameter)
        {
            Task runningTask = ExecuteAsync((T)parameter);

            runningTasks.Add(runningTask);

            try
            {
                await runningTask;
            }
            finally
            {
                runningTasks.Remove(runningTask);
            }
        }

        /// <inheritdoc />
        public abstract Task ExecuteAsync(T parameter);

        private void OnRunningTasksChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}