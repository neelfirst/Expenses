#!/usr/bin/python

# test program for applyRules
# eventually this should be a programmatically generated script
# that is imported to and run from process

import sys
import csv

def enum(**enums):
	return type('Enum', (), enums)

def applyRules(date, desc, cost, category):
	# bank of rules - assigns a label to an expense row
	Rules = enum (	Food='Food',Rent='Rent',Util='Util',Home='Home',Gear='Gear',Cats='Cats',
			Trans='Trans',Travel='Travel',Health='Health',Ent='Ent',Misc='Misc' )

	if 'MONTE CRISTO' in desc:
		return Rules.Food
	if 'MONTEREY MARKET' in desc:
		return Rules.Food
	if 'COUNTRY CHEESE' in desc:
		return Rules.Food
	if 'TRADER JOE' in desc:
		return Rules.Food
	if 'Video On Demand' in desc:
		return Rules.Ent
	if 'PET FOOD' in desc:
		return Rules.Cats
	if 'VZWRLSS' in desc:
		return Rules.Util

	return Rules.Misc
	
# main
file = open('expenses.csv')
reader = csv.reader(file)
log = open('withrules.csv','w')
writer = csv.writer(log)

for line in reader:
	try:
		date = line[0]
		desc = line[1]
		cost = line[2]
		category = line[3]
		rule = applyRules(date, desc, cost, category)
		writer.writerow([date, desc, cost, rule])
	except Exception, e:
		print line
		print e
		break
