#!/usr/bin/python

import sys, csv
import rules
import subprocess

def modifyRules(desc):
	# user input for new lines
	isValid = False
	while not isValid:
		print "Available rules: " + rules.getRules()
		rule = raw_input("Need a rule for \"" + desc +"\": ")
		isValid = rules.checkRule(rule)

	# slurp in the input file
	ruleFile = open('rules.py','r')
	tempFile = open('rules.temp','w')
	lines = ruleFile.readlines()
	for line in lines[:-1]:
		tempFile.write(line)

	# write out the new rule and replace the last line
	tempFile.write('\tif \''+desc+'\' in desc:\n')
	tempFile.write('\t\treturn Rules.'+rule+'\n')
	tempFile.write('\treturn \'none\'\n')

	# close and replace file
	ruleFile.close()
	tempFile.close()
	subprocess.call('mv rules.temp rules.py',shell=True)

	# reload the rules module because it has changed
	reload(rules)

	return rule

# instead of sys.argv try reading the samba folder
try:
	f = open(sys.argv[1])
	reader = csv.reader(f)
except:
	print "not a valid CSV file"
	sys.exit(1)

log = open('expenses.csv','a')
writer = csv.writer(log)
chkban = ['Express','Chase','VGI','FID']
cardban = ['Amazon.com','AMAZON MKT']

for list in reader:
	try:
		if (len(list) == 5 and list[0] == "Sale"):
			cost = -1 * float(list[-1])
			date = list[1]
			desc = list[3].replace('\'','')
			category = 'none'
			if not any(i in desc for i in cardban):
				rule = rules.applyRules(date, desc, cost, category)
				if rule == 'none':
					rule = modifyRules(desc)
				writer.writerow([date,desc,cost,rule])
		elif (len(list) == 32 and list[5] == "Amazon.com" and list[12] != '1001' and list[13] != 'x'):
			date = list[0]
			desc = list[2].replace('\'','')
			cost = float(list[24][1:])+float(list[25][1:])
			category = list[3]
			rule = rules.applyRules(date, desc, cost, category)
			if rule == 'none':
				rule = modifyRules(desc)
			writer.writerow([date,desc,cost,rule])
		elif (len(list) == 8 and list[0] == "DEBIT" and not any(i in list[2] for i in chkban)):
			date = list[1]
			desc = list[2]
			cost = -1 * float(list[3])
			category = 'none'
			rule = rules.applyRules(date, desc, cost, category)
			if rule == 'none':
				rule = modifyRules(desc)
			writer.writerow([date,desc,cost,rule])
	except Exception, e:
		print list
		print e
		break
