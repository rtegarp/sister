import xmlrpclib

proxy = xmlrpclib.ServerProxy("http://localhost:8000/")
data_list = proxy.read_xml(4)
i=0
while i< len(data_list):
    print data_list[i]
    i=i+1
proxy.empty_list()