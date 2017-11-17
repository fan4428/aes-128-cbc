var crypto = require('crypto');

  var key = "sfe023f_9fd&fwfl"
  var iv = "sfe023f_9fd&fwfl"
  var data = "fan123fdsajfkldsjak_8"

  var cipher = crypto.createCipheriv('aes-128-cbc', key, iv);
  var crypted = cipher.update(data, 'utf8', 'binary');
  crypted += cipher.final('binary');
  crypted = new Buffer(crypted, 'binary').toString('base64');
  console.log("encode:" + crypted)

  var decode = new Buffer(crypted, "base64").toString("binary")
  cipher = crypto.createDecipheriv('aes-128-cbc', key, iv);
  crypted = cipher.update(decode, 'binary', 'utf8');
  crypted += cipher.final('utf8');

  console.log("decode:" + crypted)
