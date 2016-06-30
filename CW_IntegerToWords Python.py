def int_to_english(n):
    #define each type of number
    units = ['','one','two','three','four','five','six','seven','eight','nine']
    teens = ['','eleven','twelve','thirteen','fourteen','fifteen','sixteen', 
             'seventeen','eighteen','nineteen']
    tens = ['','ten','twenty','thirty','forty','fifty','sixty','seventy', 
            'eighty','ninety']
    thousands = ['','thousand','million','billion','trillion','quadrillion', 
                 'quintillion','sextillion','septillion','octillion', 
                 'nonillion','decillion','undecillion','duodecillion', 
                 'tredecillion','quattuordecillion','sexdecillion', 
                 'septendecillion','octodecillion','novemdecillion', 
                 'vigintillion']
    words = [] #create an empty list
    num=n
    if num==0: words.append('zero')
    else:
        numStr = '%d'%num #take the modulus of the number
        numStrLen = len(numStr)
        groups = (numStrLen+2)/3
        numStr = numStr.zfill(groups*3) #fill the groups by type
        for i in range(0,groups*3,3):
            h,t,u = int(numStr[i]),int(numStr[i+1]),int(numStr[i+2])
            g = groups-(i/3+1) 
            if h>=1:
                words.append(units[h])
                words.append('hundred') #add hundreds
            if t>1:
                words.append(tens[t]) #add tens
                if u>=1: words.append(units[u])
            elif t==1:
                if u>=1: words.append(teens[u]) #add teens
                else: words.append(tens[t])
            else:
                if u>=1: words.append(units[u]) #add thousands
            if (g>=1) and ((h+t+u)>0): words.append(thousands[g])
    if len(words)>0: return ' '.join(words) #if the list is not empty, join the list together
    return words