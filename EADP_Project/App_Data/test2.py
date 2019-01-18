def raw_log_2(raw_text):
    extractedText = raw_text.split('\n')
    del extractedText[-1]
    text_list = []
    for item in extractedText:
        splitText = item.split(' ')
        text_list.append(
            splitText[0] + ' ' + splitText[4] + ' ' + splitText[5].split(':')[0] + ':' + splitText[5].split(':')[
                1] + ' ' + splitText[6])

    text_list.sort()

    final_list = [[x, text_list.count(x)] for x in set(text_list)]
    flagged_list = []
    for item in final_list:
        flagged_list.append(item[0] + ' occurences : ' + str(item[1]))

    flag = open("C:/Users/Justin Tan/PycharmProjects/ASP_Test/flag_list.txt", "w")
    for line in flagged_list:
        flag.writelines(str(line) + "\n")
    flag.close()