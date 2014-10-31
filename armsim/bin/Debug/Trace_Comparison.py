
import re, codecs
with codecs.open("trace.log", 'r', encoding="utf-16-le") as f:
	string = ""
	li = []
	number = 0
	try:
		while 1 < 2:
			#check to see if new lines get added
			string = f.readline().strip() + " "
			string += f.readline().strip() + " "
			string += f.readline().strip()
			#print (str(number) + " string: " + string)
			string2 = input("").strip() + " " 
			string2 += input("").strip() + " "
			string2 += input("").strip()
			string2 = string2.replace("   ", " ")
			string2 = string2.replace("  ", " ")
			#print (str(number) +" string2: " + string2)
			li.append(string)
			li.append(string2)
			number += 1
	except:
		#print("main list: " + str(len(li)))
		a = 0
		while a < len(li):
			string = li[a]
			a += 1
			string2 = li[a]
			a += 1

			list1 = []
			list2 = []

			list1 = string.split(" ")
			list2 = string2.split(" ")
			
			num = 0
			for i in range(0, 8):
				if list2[i].strip() != list1[i].strip() and i != 2:
					print("**" + list1[i].strip() + "** ",end="")
				else:
					print(list1[i].strip() + " ", end="")
			print(" ")
			print("     ", end="")
			for i in range(8, 14):
				if list2[i].strip() != list1[i].strip():
					print("**" + list1[i].strip() + "** ", end="")
				else:
					print(list1[i].strip() + " ", end="")
			print(" ")
			print("     ", end="")
			for i in range(14, 19):
				if list2[i].strip() != list1[i].strip():
					print("**" + list1[i].strip() + "** ", end="")
				else:
					print(list1[i].strip() + " ",end="")
			print("")
			print("")