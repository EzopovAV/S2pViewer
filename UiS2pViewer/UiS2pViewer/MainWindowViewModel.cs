﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UiS2pViewer.Interfaces;
using UiS2pViewer.Models.Interfaces;

namespace UiS2pViewer
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private readonly IDialogService _dialogService;
		private readonly ISourceDataProvider _sourceDataProvider;

		public MainWindowViewModel(IDialogService dialogService, ISourceDataProvider sourceDataProvider)
		{
			_dialogService = dialogService;
			_sourceDataProvider = sourceDataProvider;

			SourceDatas = new ObservableCollection<ISourceData>();
		}

		public ObservableCollection<IGraph> Graphs { get; set; }
		public ObservableCollection<ISourceData> SourceDatas { get; set; }

		private IGraph _selectedGraph;
		public IGraph SelectedGraph
		{
			get { return _selectedGraph; }
			set
			{
				_selectedGraph = value;
				OnPropertyChanged("SelectedGraph");
			}
		}

		private RelayCommand _openCommand;
		public RelayCommand OpenCommand
		{
			get
			{
				return _openCommand ??
					(_openCommand = new RelayCommand(obj =>
					{
						try
						{
							if (_dialogService.OpenFileDialog() == true)
							{
								var sourceData = _sourceDataProvider.GetSourceData(_dialogService.FilePath);
								SourceDatas.Add(sourceData);
								_dialogService.ShowMessage("File is opend.");
							}
						}
						catch (Exception ex)
						{
							_dialogService.ShowMessage(ex.Message);
						}
					}));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}