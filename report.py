#!/usr/bin/python

import csv
import sys
from datetime import datetime
import calendar
import rules

def getType():
	range = int(raw_input("Enter report range. 1 - Monthly, 2 - Yearly, 3 - Custom: "))
	if range == 1:
		month = int(raw_input("Enter month, 1-12: "))
		if (month < 1 or month > 12):
			print "fuck you man"
			sys.exit(1)
		else:
			return 'm'+str(month)+'-y'+str(datetime.now().year)
	if range == 2:
		year = int(raw_input("Enter four-digit year: "))
		return 'y'+str(year)
	if range == 3:
		strStartDate = raw_input("Enter start date, mm/dd/yyyy: ")
		strStopDate = raw_input("Enter stop date, mm/dd/yyyy: ")
		return 'c-'+strStartDate+"-"+strStopDate
	print "Invalid input. Exiting... asshole."
	sys.exit(1)

def getStart(report, length):
	if length == 1:
		year = report[0].replace('y','')
		return datetime(int(year),1,1)
	if length == 2:
		month = report[0].replace('m','')
		year = report[1].replace('y','')
		return datetime(int(year),int(month),1)
	if length == 3:
		[month, day, year] = report[1].split('/')
		return datetime(int(year),int(month),int(day))
	print "Invalid start date. Exiting."
	sys.exit(1)

def getStop(report, length):
	if length == 1:
		year = report[0].replace('y','')
		return datetime(int(year),12,31)
	if length == 2:
		month = report[0].replace('m','')
		year = report[1].replace('y','')
		return datetime(int(year),int(month),calendar.monthrange(int(year),int(month))[1])
	if length == 3:
		[month, day, year] = report[2].split('/')
		return datetime(int(year),int(month),int(day))
	print "Invalid stop date. Exiting."
	sys.exit(1)

report = getType().split('-')
length = len(report)
f = open(rules.getPath()+'expenses.csv','r')
reader = csv.reader(f)
startDate = getStart(report,length)
stopDate = getStop(report,length)
ruleList = rules.getRules().split(',')
costList = [0] * len(ruleList)
itemList = ['']
sum = 0
category = raw_input("All or "+rules.getRules()+": ")

for line in reader:
	date = datetime.strptime(line[0], '%m/%d/%Y')
	if (date >= startDate and date <= stopDate):
		index = ruleList.index(line[-1])
		costList[index] = costList[index] + float(line[-2])
	if (category == line[3]):
		itemList.append(line)
itemList.remove('')
if (category == "All"):
	for i in range(0,len(ruleList)):
		sum = sum + costList[i]
		print ruleList[i]+'\t'+str(costList[i])
elif (category in ruleList):
	for item in itemList:
		print item[0]+'\t'+item[1]+'\t'+item[2]
		sum = sum + float(item[2])
else:
	print "Not a recognized category."
print "Total\t"+str(sum)
