def raw_log_2(raw_text):
    extractedText = raw_text.splitlines()
    print(extractedText)
    del extractedText[-1]
    text_list = []
    for item in extractedText:
        splitText = item.split(' ')
        text_list.append(
            splitText[0] + ' ' + splitText[4] + ' ' + splitText[5].split(':')[0] + ':' + splitText[5].split(':')[1] + ' ' + splitText[6])

    text_list.sort()

    final_list = [[x, text_list.count(x)] for x in set(text_list)]
    flagged_list = []
    for item in final_list:
        flagged_list.append(item[0] + ' occurrences : ' + str(item[1]))

    flag = open("C:/Users/Yun/Desktop/ASP_Project/ASP_Project/EADP_Project/app_data/flag_list.txt", "w")
    #flag = open("C:/Users/Justin Tan/Documents/GitHub/ASP_Project/EADP_Project/App_Data/flag_list.txt", "w")
    for line in flagged_list:
        flag.writelines(str(line) + "\n")
    flag.close()



