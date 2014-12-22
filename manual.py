#!/usr/bin/python

import sys
import csv
import rules
import calendar
from datetime import datetime

try:
	f = open(rules.getPath()+'expenses.csv','a')
	writer = csv.writer(f)

	if (datetime.now().year != 2014):
		raise Exception("Update rental cost for the new year.")

	desc = sys.argv[1]
	month = int(sys.argv[2])

	if (desc == 'Rent'):
		date = str(month)+"/01/2014"
		cost = 1219.00
	elif (desc == 'PGE' or desc == 'EBMUD'):
		date = str(month)+"/"+str(calendar.monthrange(datetime.now().year,month)[1])+"/"+str(datetime.now().year)
		cost = float(sys.argv[3])
	else:
		raise Exception("Invalid manual option.")

	rule = rules.applyRules(date,desc,cost,'none')
	if rule == 'none':
		print "Modify rules manually."
		sys.exit(1)

	writer.writerow([date,desc,cost,rule])
except Exception, e:
	print e
	print "Usage: ./manual.py [Rent|PGE|EBMUD] [mm] [cost]"
	sys.exit(1)

f.close()
