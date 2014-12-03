using System;
using System.Diagnostics;

namespace RadiUX.Model.Structures {

	/*================================================================================================*/
	public class Anim {

		public enum Ease {
			Linear,
			In,
			Out,
			InOut,
			OutIn
		};

		public bool Active { get; private set; }
		public float Duration { get; private set; }

		private readonly Stopwatch vWatch;
		private Ease vEase;
		private float vEaseStrength;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Anim(float pDuration) {
			Duration = pDuration;
			vWatch = new Stopwatch();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Start(Ease pEase=Ease.Linear, float pEaseStrength=1) {
			vEase = pEase;
			vEaseStrength = Math.Max(0, pEaseStrength);

			vWatch.Reset();
			vWatch.Start();
			Active = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Pause() {
			vWatch.Stop();
			Active = false;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public float GetRawProgress() {
			float prog = (float)vWatch.Elapsed.TotalMilliseconds/Duration;

			if ( prog >= 1 ) {
				Pause();
			}

			return Math.Min(1, prog);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public float GetEasedProgress() {
			return GetEasedProgress(vEase, vEaseStrength, GetRawProgress());
		}

		/*--------------------------------------------------------------------------------------------*/
		public static float GetEasedProgress(Ease pEase, float pEaseStrength, float pProgress) {
			switch ( pEase ) {
				case Ease.Linear:
					return pProgress;

				case Ease.In:
					return (float)Math.Pow(pProgress, 1+pEaseStrength);

				case Ease.Out:
					return 1-(float)Math.Pow(1-pProgress, 1+pEaseStrength);

				case Ease.OutIn:
				case Ease.InOut:
					if ( pProgress < 0.5 ) {
						return GetEasedProgress((pEase == Ease.InOut ? Ease.In : Ease.Out),
							pEaseStrength, pProgress*2)/2f;
					}

					return GetEasedProgress((pEase == Ease.InOut ? Ease.Out : Ease.In),
						pEaseStrength, (pProgress-0.5f)*2)/2f+0.5f;
			}

			return 0;
		}

	}


	/*================================================================================================*/
	public class Anim<T> : Anim {

		public Func<T, T, float, T> ProgressValueFunc { get; set; }
		public T From { get; set; }
		public T To { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Anim(float pDuration) : base(pDuration) {
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public T GetProgressValue() {
			if ( ProgressValueFunc == null ) {
				throw new ArgumentNullException("ProgressValueFunc");
			}

			return ProgressValueFunc(From, To, GetEasedProgress());
		}

	}

}
