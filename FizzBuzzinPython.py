def Initialize():
    for i in range(1,101):
        FizzBuzz(i)
        
def FizzBuzz(num):
    if num % 5 == 0 and num % 3 == 0:
        print "FizzBuzz"
    elif num % 5 == 0:
        print "Fizz"
    elif num % 3 == 0:
        print "Buzz"
    else:
        print num

Initialize()