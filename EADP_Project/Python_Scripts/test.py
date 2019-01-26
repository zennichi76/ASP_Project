def raw_log(raw_text):
    #Create script for Detect for high amounts of traffic per day
    raw_text = raw_text.split('\n')
    raw_log_list = []
    ip_list = []
    for line in raw_text:
        if line != "":
            raw_log_list.append(line)
            data = line.split(' ')
            ip = data[0]
            ip_list.append(ip)

    checking_ip_list = []
    count_list = []
    for ip in ip_list:
        if ip in checking_ip_list:
            continue
        else:
            checking_ip_list.append(ip)
            count = ip_list.count(ip)
            count_list.append(count)

    #checking_ip = open("C:/Users/Yun/Desktop/ASP_Project/ASP_Project/EADP_Project/App_data/ip_list.txt", "w")
    checking_ip = open("C:/Users/Justin Tan/Documents/GitHub/ASP_Project/EADP_Project/App_Data/ip_list.txt", "w")
    for line in checking_ip_list:
        checking_ip.writelines(line + "\n")
    checking_ip.close()

    #counting = open("C:/Users/Yun/Desktop/ASP_Project/ASP_Project/EADP_Project/App_data/count_list.txt", "w")
    counting = open("C:/Users/Justin Tan/Documents/GitHub/ASP_Project/EADP_Project/App_Data/count_list.txt", "w")
    for line in count_list:
        counting.writelines(str(line) + "\n")
    counting.close()

#end of per day detection






    # structured_list = []
    # ip_datetime_list = []
    # for line in raw_text:
    #     data = line.split(' ')
    #     if data[0] in ip_datetime_list:
    #         continue
    #     else:
    #         ip_datetime_list.append(data[0] + " " + data[5] + data[6])
    #         data = data[0] + " " + data[5] + data[6] + " " + data[10]
    #         structured_list.append(data)
    #
    # num = 0
    # record_list = []
    # for i in ip_datetime_list:
    #     record_list.append([])
    #     for j in structured_list:
    #         if i in j:
    #             record_list[num].append(j)
    #     num += 1
    #
    # num = 0
    # count = 0
    # flag_list = []
    # while num < len(record_list):
    #     count = len(record_list[num])
    #     if count > 15:
    #         flag_list.append(record_list[num][0])
    #     num += 1
    #
    # final_flag_list = []
    # for i in flag_list:
    #     if i not in final_flag_list:
    #         final_flag_list.append(i)
    #
    # flag_list = []
    # for line in final_flag_list:
    #     data = line.split(' ')
    #     data = data[0] + " " + data[1]
    #     flag_list.append(data)
    #
    # flag = open("C:/Users/Justin Tan/PycharmProjects/ASP_Test/flag_list.txt", "w")
    # for line in flag_list:
    #     flag.writelines(str(line) + "\n")
    # flag.close()

# ------------------------------------------------

    # raw_log_list = []
    # structured_list = []
    # ip_time_list = []
    # for line in raw_text:
    #     raw_log_list.append(line)
    #     data = line.split(' ')
    #     # data = data[0] + " " + data[4] + " " + data[5] + data[6] + " " + data[10]
    #     if data[0] in ip_time_list:
    #         continue
    #     else:
    #         ip_time_list.append(data[0] + " " + data[5] + data[6])
    #
    # num = 0
    # record_list = []
    # for i in ip_time_list:
    #     record_list.append([])
    #     for j in structured_list:
    #         if i in j:
    #             record_list[num].append(j)
    #     num += 1
    #
    # # num = 0
    # # num_ip = 0
    # # num_time = 0
    # # num_check = 0
    # # count = 0
    # # flag_list = []
    # # while num_ip < len(record_list):
    # #     for line in record_list[num_ip][num_time]:
    # #         data = record_list[num_ip][num_time].split(' ')
    # #         time = data[1]
    # #         while num < len(record_list[num_ip]):
    # #             if time in record_list[num_ip][num_time]:
    # #                 count += 1
    # #                 num_time += 1
    # #                 num += 1
    # #             else:
    # #                 num_time += 1
    # #                 num += 1
    # #             #num_time = 0
    # #             if count >= 2:
    # #                 flag_list.append(record_list[num_ip][num_time])
    # #                 count = 0
    # #             num_time = 0
    # #     num_ip += 1
    #
    # num = 0
    # num_ip = 0
    # num_time = 0
    # num_check = 0
    # count = 0
    # flag_list = []
    # while num_ip < len(record_list):
    #     for line in record_list[num_ip]:
    #         if line in record_list[num_ip][num_time]:
    #             count += 1
    #         else:
    #             continue
    #         if count >= 1:
    #             flag_list.append(line)
    #             count = 0
    #     num_ip += 1


    # final_result = raw_text
    # f = open("C:/Users/Justin Tan/PycharmProjects/ASP_Test/blank.txt", "w")
    # f.write(final_result)
    # f.close()
