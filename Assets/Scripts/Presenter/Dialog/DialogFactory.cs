using UnityEngine;

#pragma warning disable 0649

namespace MvpSample {

	public class DialogFactory : MonoBehaviour, IDialogFactory {

		class Factory<TModel> where TModel : DialogUseCsaeBase {

			public static string PrefabPath { get; set; }

			public static DialogPresenterBase<TModel> Create(TModel model) {
				var prefab = Resources.Load<DialogPresenterBase<TModel>>(PrefabPath);
				var presenter = Instantiate(prefab);
				
				presenter.Run(model);
				return presenter;
			}

		}


		[SerializeField]
		DialogManager manager;

		
		void Awake() {
			Factory<OneButtonDialogUseCsae>.PrefabPath = "OneButtonDialog";
		}

		void IDialogFactory.Create<TModel>(TModel model) {
			var presenter = Factory<TModel>.Create(model);
			manager.Add(presenter);
		}

	}

}