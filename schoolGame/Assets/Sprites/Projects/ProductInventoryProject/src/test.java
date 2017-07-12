import java.util.Scanner;

public class test {
	public static void main (String [] args) {
		Inventory inv = new Inventory();
		Scanner keyboard = new Scanner(System.in);
		int optionMenu = 0;

		do {
			System.out.println("| |||||||||||||||||||| |");
			System.out.println("|   Product Inventory  |");
			System.out.println("| -------------------- |");
			System.out.println("|  1) New Product:     | ");
			System.out.println("|  2) Remove Product:  | ");
			System.out.println("|  3) Display All:     | ");
			System.out.println("|  4) Quit Program:    | ");
			System.out.println("| |||||||||||||||||||| |");
			System.out.print("input: ");

			optionMenu = keyboard.nextInt();
			
			 if (optionMenu == 1){
				String id = "";
				String price = "";
				int quant = 0;
				System.out.println("\nNew Product");
				System.out.println("------------");
				 keyboard.nextLine();
				System.out.print("Enter the ID: ");
				id = keyboard.nextLine();
				System.out.print("Enter the price: ");
				price = keyboard.nextLine();
				System.out.print("Enter the quantity: ");
				quant = keyboard.nextInt();
				inv.setProduct(new Product(id, price, quant));
				System.out.println("");

			}
			 else if (optionMenu == 2){
				 System.out.print("Please enter the ID of the product you wish to remove: ");
				 keyboard.nextLine();
				 String id = keyboard.nextLine();

				 inv.removeProduct(id);
			 }
			 
			 else if (optionMenu == 3){
			 	inv.displayAll();
			 }
		} while(optionMenu != 4);
		keyboard.close();
		System.out.println("The program has quit. ");

		
	}
}
