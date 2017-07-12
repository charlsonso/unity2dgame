# Airline / Hotel Reservation System - Create a reservation system which books airline
# seats or hotel rooms. It charges various rates for particular sections of the plane or hotel.
# Example, first class is going to cost more than coach. Hotel rooms have penthouse suites which
# cost more. Keep track of when rooms will be available and can be scheduled.
class HotelReservationSystem:

    num_of_hotel_reservations = 0

    def __int__(self, hotel_room, section, rate):
        self.hotel_room = hotel_room
        self.section = section
        self.rate = rate
        HotelReservationSystem.num_of_hotel_reservations += 1

    def get_hotel_room(self):
        return self.hotel_room

    def get_section(self):
        return self.section

    def get_rate(self):
        return self.rate

menuOption = 0
section = 'A'
print("____________________________")
print("| Hotel Reservation System |")
print("|__________________________|")
print("| 1) Reserve A Hotel       |")
print("| 2) Exit Program          |")
print("|__________________________|")

menuOption = int(input("input: "))

if menuOption == 1:
    print("___________________________________________________________________________________________________________")
    print("|                                         Reserve A Hotel                                                 |")
    print("___________________________________________________________________________________________________________")
    print("Enter the section you wish to stay in: ")
    print("A) Single: A room assigned to one person. May have one or more beds.")
    print("B) Double: A room assigned to two people. May have one or more beds.")
    print("C) Triple: A room assigned to three people. May have two or more beds.")
    print("D) Quad: A room assigned to four people. May have two or more beds.")
    print("E) Queen: A room with a queen-sized bed. May be occupied by one or more people.")
    print("F) King: A room with a king-sized bed. May be occupied by one or more people.")
    print("G) Twin: A room with two beds. May be occupied by one or more people.")
    print("H) Double-double: A room with two double (or perhaps queen) beds. May be occupied by one or more people.")
    print("I) Studio: A room with a studio bed – a couch that can be converted into a bed. "
          "\nMay also have an additional bed.")
    print("J) Master Suite: A parlour or living room connected to one or more bedrooms.")
    print("K) Mini-Suite or Junior Suite: A single room with a bed and sitting area."
          "\nSometimes the sleeping area is in a bedroom separate from the parlour or living room.")
    section = str(input("Please select a character: "))
