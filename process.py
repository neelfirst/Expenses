#!/usr/bin/python

import sys
import csv

try:
	file = open(sys.argv[1])
	reader = csv.reader(file)
except:
	print "not a valid CSV file"
	sys.exit(1)

log = open('expenses.csv','a')
writer = csv.writer(log)

for list in reader:
	try:
		if (len(list) == 5 and list[0] == "Sale"):
			cost = -1 * float(list[-1])
			date = list[1]
			desc = list[3]
			category = 'none'
			if (('Amazon.com' not in desc) and ('AMAZON MKT' not in desc)):
				writer.writerow([date,desc,cost,category])
		elif (len(list) == 32 and list[5] == "Amazon.com" and list[12] != '1001' and list[13] != 'x'):
			date = list[0]
			desc = list[2]
			cost = float(list[24][1:])+float(list[25][1:])
			category = list[3]
			writer.writerow([date,desc,cost,category])
	except Exception, e:
		print list
		print e
		break
