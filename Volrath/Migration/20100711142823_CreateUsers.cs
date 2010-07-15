namespace Volrath.Migration {
	using ActiveRecord.net.Migrate;

	public class _20100711142823_CreateUsers : Migration {
		public override void Up() {
            using (var t = CreateTable("users")) {
                t.String("name");
                t.String("email");
                t.String("password_hash");
                t.Integer("status");
                t.DateTime("password_expires");
                t.Integer("login_failed_attempts");
                t.TimeStamps();
            }
		}

		public override void Down() {
            DropTable("users");
		}
	}
}
