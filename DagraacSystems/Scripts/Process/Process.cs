namespace DagraacSystems
{
	/// <summary>
	/// 프로세스.
	/// </summary>
	public class Process : DisposableObject, IProcess
	{
		private bool _isStarted;
		private bool _isFinished;
		private bool _isPaused;

		private ProcessExecutor _processExecutor;
		private ulong _processID; // 객체의 프로세스 아이디. execute ~ finish 까지 0이 아님.

		public Process() : base()
		{
			_isStarted = false;
			_isFinished = false;
			_isPaused = false;
			_processExecutor = null;
			_processID = 0;
		}

		protected override void OnDispose(bool explicitedDispose)
		{
			base.OnDispose(explicitedDispose);
		}

		public void Reset()
		{
			_isStarted = false;
			_isFinished = false;
			_isPaused = false;
			_processExecutor = null;
			_processID = 0;

			OnReset();
		}

		public void Execute(ProcessExecutor processExecutor, ulong processID, params object[] args)
		{
			_isStarted = true;
			_isFinished = false;
			_processExecutor = processExecutor;
			_processID = processID;

			OnExecute(args);
		}

		public void Update(float deltaTime)
		{
			OnUpdate(deltaTime);
		}

		public void Finish()
		{
			if (!_isStarted || _isFinished)
				return;

			_isStarted = false;
			_isFinished = true;

			OnFinish();
		}

		public void Resume()
		{
			if (_isPaused)
			{
				_isPaused = false;
				OnResume();
			}
		}

		public void Pause()
		{
			if (!_isPaused)
			{
				_isPaused = true;
				OnPause();
			}
		}

		protected virtual void OnReset()
		{
		}

		protected virtual void OnExecute(params object[] args)
		{
		}

		protected virtual void OnUpdate(float deltaTime)
		{
		}

		protected virtual void OnPause()
		{
		}

		protected virtual void OnResume()
		{
		}

		protected virtual void OnFinish()
		{
		}

		public bool IsStarted()
		{
			return _isStarted;
		}

		public bool IsFinished()
		{
			return _isFinished;
		}

		public bool IsPaused()
		{
			return _isPaused;
		}

		public ProcessExecutor GetProcessExecutor()
		{
			return _processExecutor;
		}

		public ulong GetProcessID()
		{
			return _processID;
		}
	}
}