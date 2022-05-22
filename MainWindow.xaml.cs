using System.Threading;
using System.Windows;

namespace Vendingmachine_wpf;

public partial class MainWindow : Window {
	private readonly Thread _producer = new(Producer.ProduceBottles);
	private readonly Thread _splitter = new(Splitter.StartSplitter);
	private readonly Thread _consumeBeer = new(Consumer.ConsumeBeer);
	private readonly Thread _consumeSoda = new(Consumer.ConsumeSoda);

	public MainWindow() {
		InitializeComponent();
	}

	private void ToggleProducer(object sender, RoutedEventArgs e) {
		ProducerButton.Content = "stop producer";
		_producer.Start();
	}

	private void ToggleSplitter(object sender, RoutedEventArgs e) {
		SplitterButton.Content = "stop splitter";
		_splitter.Start();
	}

	private void ToggleSodaConsumer(object sender, RoutedEventArgs e) {
		SodaButton.Content = "stop consumer";
		_consumeSoda.Start();
	}

	private void ToggleBeerConsumer(object sender, RoutedEventArgs e) {
		BeerButton.Content = "stop consumer";
		_consumeBeer.Start();
	}
}

public class Bottle {
	public readonly int BottleId;

	public Bottle(int bottleId) {
		BottleId = bottleId;
	}
}

public class Soda : Bottle {
	public Soda(int bottleId) : base(bottleId) {
	}
}

public class Beer : Bottle {
	public Beer(int bottleId) : base(bottleId) {
	}
}